﻿using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using System.ComponentModel.DataAnnotations;

namespace PropManagerServer.Mutations.LoanMutations
{
    [ExtendObjectType("Mutation")]
    public class DeleteLoanM
    {
        public record DeleteLoanInput
        {
            [Required]
            public Guid Id { get; set; }
        }

        public async Task<bool> DeleteLoan([Service] PropManagerContext context, DeleteLoanInput input)
        {
            var loan = await context.Loans.SingleAsync(x => x.Id == input.Id);
            if (loan is not null)
            {
                loan.Deleted = true;
                await context.SaveChangesAsync(); 
            }

            return true;
        }
    }
}
