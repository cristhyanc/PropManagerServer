using PropManagerModel;
using PropManagerModel.Model;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.PropertyMutations
{
    [ExtendObjectType("Mutation")]
    public class AddPropertyM
    {
        public record AddPropertyInput
        {
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
            public string? CouncilWebSite { get; set; }
        }


        public async Task<Property> AddProperty([Service] PropManagerContext propManagerContext, AddPropertyInput input)
        { 
                var property = new Property();
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
                property.CouncilWebSite=input.CouncilWebSite;
                propManagerContext.Add(property);
                await propManagerContext.SaveChangesAsync();
                return property;
        }
    }
}
