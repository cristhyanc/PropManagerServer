using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.RentMutations
{
    [ExtendObjectType("Mutation")]
    public class DeleteRentM
    {
        public record DeleteRentInput
        {
            [Required]
            public Guid Id { get; set; }
        }
        public async Task<bool> DeleteRent([Service] PropManagerContext context, DeleteRentInput input)
        {
            var rent = await context.Rents.SingleAsync(x => x.Id == input.Id);
            if (rent is not null)
            {
                rent.Deleted = true;
                await context.SaveChangesAsync();
               
            }

            return true;
        }
    }
}
