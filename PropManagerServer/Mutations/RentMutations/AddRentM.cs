using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.RentMutations
{
    [ExtendObjectType("Mutation")]
    public class AddRentM
    {
        public record AddRentInput
        {
            [Required]
            public decimal RentPrice { get; set; }
            public decimal Bond { get; set; }
            public RentPeriod PaymentPeriod { get; set; }
            [Required]
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset? EndDate { get; set; }
            [Required]
            public Guid TenantId { get; set; }           
        }

        public async Task<Rent> AddRent([Service] PropManagerContext context, AddRentInput input)
        {
            try
            {
                var tenant = await context.Tenants.SingleAsync(x => x.Id == input.TenantId && !x.Deleted);
                if (tenant is not null)
                {
                    var rent = new Rent();
                    rent.StartDate = input.StartDate;
                    rent.RentPrice=input.RentPrice;
                    rent.Bond=input.Bond;
                    rent.PaymentPeriod=input.PaymentPeriod;
                    rent.TenantId= tenant.Id;
                    rent.EndDate = input.EndDate;                    
                    await context.AddAsync(rent);
                    await context.SaveChangesAsync();
                    return rent;
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
