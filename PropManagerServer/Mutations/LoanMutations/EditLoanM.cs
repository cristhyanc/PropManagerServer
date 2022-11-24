using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using PropManagerModel.Model;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.LoanMutations
{
    [ExtendObjectType("Mutation")]
    public class EditLoanM
    {
        public record EditLoanInput
        {
            [Required]
            public Guid Id { get; set; }
            [Required]
            public string LenderName { get; set; } = null!;
            [Required]
            public decimal Amount { get; set; }
            public decimal? Interest { get; set; }
            public LoanTypes LoanType { get; set; }
            public decimal? LMI { get; set; }
            public int? Years { get; set; }
            public DateTimeOffset? DateOfLoan { get; set; }

        }

        public async Task<Loan> EditLoan([Service] PropManagerContext context, EditLoanInput input)
        {
            var loan = await context.Loans.SingleAsync(x => x.Id == input.Id);
            if (loan is not null)
            {
              
                loan.LenderName = input.LenderName;
                loan.Interest = input.Interest;
                loan.LoanType = input.LoanType;
                loan.LMI = input.LMI;               
                loan.Amount = input.Amount;
                loan.Years = input.Years;
                loan.DateOfLoan = input.DateOfLoan;
                await context.SaveChangesAsync();
                return loan;
            }

            return null;
        }
    }
}
