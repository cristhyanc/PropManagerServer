using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropManagerModel.Model
{
    public class Expense : IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public decimal? Price  { get; set; }
        public decimal TotalDeductable { get; set; }
        public Property Property { get; set; } = null!;
        public Guid PropertyId { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }
    }
}
