using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.RentMutations
{
    [ExtendObjectType("Mutation")]
    public class EditRentM
    {
        public record EditRentInput
        {
            [Required]
            public Guid Id { get; set; }
            [Required]
            public decimal RentPrice { get; set; }
            public decimal Bond { get; set; }
            public RentPeriod PaymentPeriod { get; set; }
            [Required]
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset? EndDate { get; set; }
        }

        public async Task<Rent> EditRent([Service] PropManagerContext context, EditRentInput input)
        {
            var rent = await context.Rents.SingleAsync(x => x.Id == input.Id);
            if (rent is not null)
            {
                rent.StartDate = input.StartDate;
                rent.RentPrice = input.RentPrice;
                rent.Bond = input.Bond;
                rent.PaymentPeriod = input.PaymentPeriod;
                rent.EndDate = input.EndDate;
                await context.SaveChangesAsync();
                return rent;
            }

            throw new ArgumentException("Rent doesn't exist");

        }
    }
}
