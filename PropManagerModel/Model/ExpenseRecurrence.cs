using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropManagerModel.Model
{
    public class ExpenseRecurrence : IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Expense Expense { get; set; } = null!;
        public Guid ExpenseId { get; set; }
        public DateTimeOffset RecurrenceDate { get; set; }
        public bool Deleted { get; set; }
        public bool Completed { get; set; }

    }
}
