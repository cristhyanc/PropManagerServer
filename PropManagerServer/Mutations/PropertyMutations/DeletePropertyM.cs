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
            var property = await context.Properties.Include(x=> x.Loans).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (property is not null)
            {
                property.Deleted = true;
                property.Loans.ForEach(x => x.Deleted = true);

                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
