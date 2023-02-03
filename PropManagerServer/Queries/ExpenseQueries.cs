using PropManagerModel.Model;
using PropManagerModel;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PropManagerServer.Queries
{
    [ExtendObjectType("Query")]
    public class ExpenseQueries
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Expense> GetExpenses([Service] PropManagerContext propManagerContext)
        {
            return propManagerContext.Expenses.Where(x => !x.Deleted).Include(x => x.Property);
        }
    }

   

}
