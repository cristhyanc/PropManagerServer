using PropManagerModel.Model;
using PropManagerModel;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Queries
{
    [ExtendObjectType("Query")]
    public class RentQueries
    {
        [UseFiltering]
        public IQueryable<Rent> GetRents([Service] PropManagerContext propManagerContext)
        {
            return propManagerContext.Rents.Where(x => !x.Deleted).Include(x => x.Tenant);
        }
    }
}
