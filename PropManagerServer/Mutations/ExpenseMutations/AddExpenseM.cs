using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.ExpenseMutations
{
    [ExtendObjectType("Mutation")]
    public class AddExpenseM
    {

        public record AddExpenseInput
        {
            [Required]
            public string Title { get; set; } = default!;
            public string? Description { get; set; }
            public decimal? Price { get; set; }
            public string? Reference { get; set; }
            public string? CompanyName { get; set; }
            public DateTimeOffset? DueDate { get; set; }
            public RecurranceTypes ExpenseRecurrence { get; set; }
            public int? TotalRecurrence { get; set; }
            public bool Paid { get; set; }
            [Required]
            public Guid PropertyId { get; set; }
            [Required]
            public DateTimeOffset ExpenseDate { get; set; }
            public bool IsDirectDebit { get; set; }
        }

        public async Task<Expense> AddExpense([Service] PropManagerContext context, AddExpenseInput input)
        {
            var property = await context.Properties.SingleAsync(x => x.Id == input.PropertyId);
            if (property is not null)
            {
                input.TotalRecurrence = input.TotalRecurrence == null || input.ExpenseRecurrence==RecurranceTypes.OneOffPayment 
                    ? 1 : input.TotalRecurrence;

                var expenses = new List<Expense>();

                var nextDate = input.DueDate == null ? input.ExpenseDate: input.DueDate.Value ;

                for (int i = 0; i < input.TotalRecurrence; i++)
                {
                    var expense = new Expense();
                    expense.Title = input.Title;
                    expense.Description = input.Description;
                    expense.Price = input.Price;
                    expense.IsDirectDebit = input.IsDirectDebit;
                    expense.PropertyId = input.PropertyId;
                    expense.ExpenseDate = input.DueDate == null ? nextDate : input.ExpenseDate;
                    expense.Reference = input.Reference;
                    expense.CompanyName = input.CompanyName;
                    expense.DueDate = input.DueDate == null ? null : nextDate;
                    expense.Paid = input.Paid;
                    expense.ExpenseRecurrence = input.ExpenseRecurrence;
                    expenses.Add(expense);

                    nextDate = GetNextDate(nextDate, input.ExpenseRecurrence);
                }



                await context.AddRangeAsync(expenses);
                await context.SaveChangesAsync();
                return expenses.First();
            }

            throw new ArgumentException("Property doesn't exist");
        }

        DateTimeOffset GetNextDate(DateTimeOffset currentDate, RecurranceTypes recurrance)
        {
            switch (recurrance)
            {
                case RecurranceTypes.OneOffPayment:
                    return currentDate;
                case RecurranceTypes.Weekly:
                    return currentDate.AddDays(7);
                case RecurranceTypes.Fortnightly:
                    return currentDate.AddDays(14);
                case RecurranceTypes.Monthly:
                    return currentDate.AddMonths(1);
                case RecurranceTypes.Quarterly:
                    return currentDate.AddMonths(3);
                case RecurranceTypes.Semiannually:
                    return currentDate.AddMonths(6);
                case RecurranceTypes.Annually:
                    return currentDate.AddYears(1);
                default:
                    return currentDate;
            }
        }
    }
}
