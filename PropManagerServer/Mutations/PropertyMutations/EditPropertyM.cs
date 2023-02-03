using PropManagerModel.Model;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Mutations.PropertyMutations
{
    [ExtendObjectType("Mutation")]
    public class EditPropertyM
    {
        public record EditPropertyInput
        {
            [Required]
            public Guid Id { get; set; }
            [Required]
            public string Address { get; set; } = null!;
            [Required]
            public string? Name { get; set; }
            public decimal? StampDuty { get; set; } = default;
            public decimal? PurchasePrice { get; set; } = default;
            public decimal? RegistrationTransferFee { get; set; } = default;
            public decimal? Rooms { get; set; } = default;
            public decimal? Bathrooms { get; set; } = default;
            public decimal? Carpark { get; set; } = default;
            public decimal? LandSize { get; set; } = default;
            public PropertyTypes? PropertyType { get; set; }
        }


        public async Task<Property> EditProperty([Service] PropManagerContext context, EditPropertyInput input)
        {

            var property = await context.Properties.SingleAsync(x => x.Id == input.Id);

            if (property == null)

            {
                throw new ArgumentException("Property doesn't exist");
            }


            property.Address = input.Address;
            property.Name = input.Name;
            property.StampDuty = input.StampDuty;
            property.PurchasePrice = input.PurchasePrice;
            property.RegistrationTransferFee = input.RegistrationTransferFee;
            property.Rooms = input.Rooms;
            property.Bathrooms = input.Bathrooms;
            property.Carpark = input.Carpark;
            property.LandSize = input.LandSize;
            property.PropertyType = input.PropertyType == null ? PropertyTypes.House : input.PropertyType.Value;

            context.Update(property);
            await context.SaveChangesAsync();
            return property;

        }
    }
}
