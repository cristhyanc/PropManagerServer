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
    public enum RecurranceTypes
    {
        OneOffPayment,
        Weekly,
        Fortnightly,
        Monthly,
        Quarterly,
        Semiannually,
        Annually

    }

    public class Expense : IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? Price  { get; set; }      
        public Property Property { get; set; } = null!;
        public Guid PropertyId { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }
        public List<ExpenseRecurrence> ExpenseRecurrences { get; set; } = new();
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public RecurranceTypes  ExpenseRecurrence { get; set; }
        public string? Reference { get; set; }
        public string? CompanyName { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public bool Paid { get; set; }

        class ConfigureModel : IEntityTypeConfiguration<Expense>
        {
            public void Configure(EntityTypeBuilder<Expense> builder)
            {
                builder.HasMany(p => p.ExpenseRecurrences)
                   .WithOne(p => p.Expense)

                   .HasForeignKey(p => p.ExpenseId)
                   .OnDelete(DeleteBehavior.NoAction);

            }
        }
    }
}
