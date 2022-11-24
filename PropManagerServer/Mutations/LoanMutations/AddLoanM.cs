using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using PropManagerModel.Model;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.LoanMutations
{
    [ExtendObjectType("Mutation")]
    public class AddLoanM
    {
        public record AddLoanInput
        {
            [Required]
            public string LenderName { get; set; } = null!;
            [Required]
            public decimal Amount { get; set; }
            
            public decimal? Interest { get; set; }
            public LoanTypes LoanType { get; set; }
            public decimal? LMI { get; set; }
            public int? Years { get; set; }
            public DateTimeOffset? DateOfLoan { get; set; }

            [Required]
            public Guid PropertyId { get; set; }
        }

        public async Task<Loan> AddLoan([Service] PropManagerContext context, AddLoanInput input)
        {
            var property = await context.Properties.SingleAsync(x => x.Id == input.PropertyId);
            if(property is not null)
            {
                var loan =new Loan();
                loan.LenderName = input.LenderName;
                loan.Interest = input.Interest;
                loan.LoanType = input.LoanType;
                loan.LMI = input.LMI;
                loan.PropertyId = input.PropertyId;
                loan.Amount = input.Amount;
                loan.Years = input.Years;
                loan.DateOfLoan = input.DateOfLoan;
                await context.AddAsync(loan);
                await context.SaveChangesAsync();
                return loan;
            }

            return null;
        }
    }
}
