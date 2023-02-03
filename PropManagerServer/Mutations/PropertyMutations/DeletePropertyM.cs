using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using static PropManagerServer.Mutations.PropertyMutations.EditPropertyM;

namespace PropManagerServer.Mutations.PropertyMutations
{
    [ExtendObjectType("Mutation")]
    public class DeletePropertyM
    {
        public record DeletePropertyInput
        {
            [Required]
            public Guid Id { get; set; }
        }

        public async Task<bool> DeleteProperty([Service] PropManagerContext context, DeletePropertyInput input)
        {
            var property = await context.Properties.Include(x=> x.Loans)
                .Include(x=> x.Expenses)
                .Include(x=>x.Tenants).ThenInclude(x=> x.Rents)
                .SingleAsync(x => x.Id == input.Id);
            if (property is not null)
            {
                property.Deleted = true;
                property.Loans.ForEach(x => x.Deleted = true);
                property.Expenses.ForEach(x => x.Deleted = true);
                property.Tenants.ForEach(x => {
                    x.Deleted = true;
                    x.Rents.ForEach(y => y.Deleted = true);
                });


                await context.SaveChangesAsync(); 
            }

            return true;
        }
    }
}
