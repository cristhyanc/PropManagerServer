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
            public decimal TotalDeductable { get; set; }
            public DateTimeOffset? DueDate { get; set; }
            public bool Paid { get; set; }
            [Required]
            public Guid PropertyId { get; set; }
            [Required]
            public DateTimeOffset ExpenseDate { get; set; }
        }

        public async Task<Expense> AddExpense([Service] PropManagerContext context, AddExpenseInput input)
        {
            var property = await context.Properties.SingleAsync(x => x.Id == input.PropertyId);
            if (property is not null)
            {
                var expense = new Expense();
                expense.Title = input.Title;
                expense.Description = input.Description;
                expense.Price = input.Price;
                expense.TotalDeductable = input.TotalDeductable;
                expense.PropertyId = input.PropertyId;
                expense.ExpenseDate = input.ExpenseDate;
                expense.Reference = input.Reference;
                expense.CompanyName = input.CompanyName;
                expense.DueDate = input.DueDate;
                expense.Paid = input.Paid;

                await context.AddAsync(expense);
                await context.SaveChangesAsync();
                return expense;
            }

            return null;
        }
    }
}
