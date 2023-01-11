using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropManagerModel.Model
{
    public enum PropertyTypes
    {
        Unit,
        House,
        TownHouse
    }

    public class Property: IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Address { get; set; } = null!;

        public PropertyTypes PropertyType { get; set; }
        public string? Name { get; set; }
        public decimal? StampDuty { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? RegistrationTransferFee { get; set; }
        public decimal? Rooms { get; set; }
        public decimal? Bathrooms { get; set; }
        public decimal? Carpark { get; set; }
        public decimal? LandSize { get; set; }
        public List<Loan> Loans { get; set; } = new();
        public List<Expense> Expenses { get; set; } = new();
        public List<Tenant> Tenants { get; set; } = new();

        public bool Deleted { get; set; }

        class ConfigureModel : IEntityTypeConfiguration<Property>
        {
            public void Configure(EntityTypeBuilder<Property> builder)
            {
                 builder.HasMany(p=> p.Loans)
                    .WithOne(p=> p.Property)
                    .HasForeignKey(p=>p.PropertyId)
                    .OnDelete(DeleteBehavior.NoAction);

                builder.HasMany(p => p.Expenses)
                    .WithOne(p => p.Property)
                    .HasForeignKey(p => p.PropertyId)
                    .OnDelete(DeleteBehavior.NoAction);

                builder.HasMany(p => p.Tenants)
                    .WithOne(p => p.Property)
                    .HasForeignKey(p => p.PropertyId)
                    .OnDelete(DeleteBehavior.NoAction);

                
            }
        }
    }
}
