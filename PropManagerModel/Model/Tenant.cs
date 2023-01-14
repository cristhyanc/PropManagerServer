using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PropManagerModel.Model
{
    public class Tenant : IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public bool IsCurrentTenant { get; set; }
        public List<Rent> Rents { get; set; } = new();
        public bool Deleted { get; set; }

        class ConfigureModel : IEntityTypeConfiguration<Tenant>
        {
            public void Configure(EntityTypeBuilder<Tenant> builder)
            {
                builder.HasMany(p => p.Rents)
                   .WithOne(p => p.Tenant)
                   .HasForeignKey(p => p.TenantId)
                   .OnDelete(DeleteBehavior.NoAction);
            }
        }
    }
}
