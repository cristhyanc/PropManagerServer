using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using static PropManagerServer.Mutations.ExpenseMutations.AddExpenseM;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.ExpenseMutations
{
    [ExtendObjectType("Mutation")]
    public class EditExpenseM
    {
        public record EditExpenseInput()
        {
            [Required]
            public string Title { get; set; } = default!;
            public string? Description { get; set; }
            public decimal? Price { get; set; }
            public decimal TotalDeductable { get; set; }
            [Required]
            public Guid Id { get; set; }
            [Required]
            public DateTimeOffset ExpenseDate { get; set; }

        }

        public async Task<Expense> EditExpense([Service] PropManagerContext context, EditExpenseInput input)
        {
            var expense = await context.Expenses.SingleAsync(x => x.Id == input.Id);
            if (expense is not null)
            {               
                expense.Title = input.Title;
                expense.Description = input.Description;
                expense.Price = input.Price;
                expense.TotalDeductable = input.TotalDeductable;                
                expense.ExpenseDate = input.ExpenseDate;                
                await context.SaveChangesAsync();
                return expense;
            }

            return null;
        }
    }
}
