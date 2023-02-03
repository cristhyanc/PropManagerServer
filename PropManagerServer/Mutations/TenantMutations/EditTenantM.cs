using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.TenantMutations
{
    [ExtendObjectType("Mutation")]
    public class EditTenantM
    {
        public record EditTenantInput
        {
            [Required]
            public Guid Id { get; set; }
            [Required]
            public string Name { get; set; } = null!;
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }          
            public bool IsCurrentTenant { get; set; }
        }

        public async Task<Tenant> EditTenant([Service] PropManagerContext context, EditTenantInput input)
        {
            var tenant = await context.Tenants.SingleAsync(x => x.Id == input.Id);
            if (tenant is not null)
            {
                tenant.Email = input.Email;
                tenant.PhoneNumber = input.PhoneNumber;
                tenant.IsCurrentTenant = input.IsCurrentTenant;
                tenant.Name = input.Name;              
                await context.SaveChangesAsync();
                return tenant;
            }

            throw new ArgumentException("Tenant doesn't exist");
        }
    }
}
