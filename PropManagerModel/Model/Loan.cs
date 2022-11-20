using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropManagerModel.Model
{
   public enum LoanTypes
    {
        InterestOnly,
        PrincipalAndInterest

    }
    public class Loan: IGuidKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LenderName { get; set; } = null!;
        public decimal? Amount { get; set; }
        public decimal? Interest { get; set; }
        public LoanTypes LoanType { get; set; }
        public decimal? LMI { get; set; }
        public Property Property { get; set; } = null!;
        public Guid PropertyId { get; set; }
        public int? Years { get; set; }
        public bool Deleted { get; set; }

    }
}
