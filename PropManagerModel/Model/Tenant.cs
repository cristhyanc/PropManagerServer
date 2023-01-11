using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Deleted { get; set; }

    }
}
