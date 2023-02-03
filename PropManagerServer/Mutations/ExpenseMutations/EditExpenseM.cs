using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using static PropManagerServer.Mutations.ExpenseMutations.AddExpenseM;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Resolvers;

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
            public string? Reference { get; set; }
            public string? CompanyName { get; set; }
            public DateTimeOffset? DueDate { get; set; }
            public RecurranceTypes ExpenseRecurrence { get; set; }
            public bool Paid { get; set; }
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
                expense.ExpenseDate = input.ExpenseDate;
                expense.CompanyName = input.CompanyName;
                expense.Reference=input.Reference;
                expense.DueDate = input.DueDate;
                expense.Paid = input.Paid;
                expense.ExpenseRecurrence = input.ExpenseRecurrence;
                await context.SaveChangesAsync();
                return expense;
            }
           
            throw new ArgumentException("Expense doesn't exist");
            
        }
    }
}
