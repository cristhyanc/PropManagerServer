using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using PropManagerModel.Model;

namespace PropManagerServer.Queries
{
    [ExtendObjectType("Query")]
    public class LoanQueries
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Loan> GetLoans([Service] PropManagerContext propManagerContext)
        {
            return propManagerContext.Loans.Where(x=> !x.Deleted).Include(x=> x.Property);
        }
    }
}
