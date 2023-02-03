using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.TenantMutations
{
    [ExtendObjectType("Mutation")]
    public class DeleteTenantM
    {
        public record DeleteTenantInput
        {
            [Required]
            public Guid Id { get; set; }
        }
        public async Task<bool> DeleteTenant([Service] PropManagerContext context, DeleteTenantInput input)
        {
            var tenant = await context.Tenants.Include(x=> x.Rents).SingleAsync(x => x.Id == input.Id);
            if (tenant is not null)
            {
                tenant.Deleted = true;
                tenant.Rents.ForEach(x => x.Deleted = true);
                await context.SaveChangesAsync();                
            }

            return true;
        }
    }
}
