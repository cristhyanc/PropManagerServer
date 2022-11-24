using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.ExpenseMutations
{
    [ExtendObjectType("Mutation")]
    public class DeleteExpenseM
    {
        public record DeleteExpenseInput
        {
            [Required]
            public Guid Id { get; set; }
        }

        public async Task<bool> DeleteExpense([Service] PropManagerContext context, DeleteExpenseInput input)
        {
            var expense = await context.Expenses.SingleAsync(x => x.Id == input.Id);
            if (expense is not null)
            {
                expense.Deleted = true;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
