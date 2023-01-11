using PropManagerModel;
using PropManagerModel.Model;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.TenantMutations
{
    [ExtendObjectType("Mutation")]
    public class AddTenantM
    {
        public record AddTenantInput
        {
            [Required]
            public string Name { get; set; } = null!;
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            [Required]
            public Guid PropertyId { get; set; }
            [Required]
            public bool IsCurrentTenant { get; set; }
        }

        public async Task<Tenant> AddTenant([Service] PropManagerContext context, AddTenantInput input)
        {
            try
            {
                var property = await context.Properties.SingleAsync(x => x.Id == input.PropertyId);
                if (property is not null)
                {
                    var tenant = new Tenant();
                    tenant.Name = input.Name;
                    tenant.PhoneNumber = input.PhoneNumber;
                    tenant.Email = input.Email;
                    tenant.PropertyId = input.PropertyId;
                    tenant.IsCurrentTenant = input.IsCurrentTenant;
                    await context.AddAsync(tenant);
                    await context.SaveChangesAsync();
                    return tenant;
                }
                return null; 

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
