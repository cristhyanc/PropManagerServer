using Microsoft.EntityFrameworkCore;
using PropManagerModel;
using PropManagerModel.Model;

namespace PropManagerServer.Queries
{
    [ExtendObjectType("Query")]
    public class PropertyQueries
    {
        [UseFiltering]
        public  IQueryable<Property> GetProperties([Service] PropManagerContext propManagerContext)
        {
            return propManagerContext.Properties.Include(x => x.Loans.Where(y=> !y.Deleted)).Where(x=> !x.Deleted);
        }
    }
}
