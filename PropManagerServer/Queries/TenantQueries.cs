using PropManagerModel.Model;
using PropManagerModel;
using Microsoft.EntityFrameworkCore;

namespace PropManagerServer.Queries
{
    [ExtendObjectType("Query")]
    public class TenantQueries
    {
        [UseFiltering]
        public IQueryable<Tenant> GetTenants([Service] PropManagerContext propManagerContext)
        {
            return propManagerContext.Tenants.Where(x => !x.Deleted).Include(x => x.Property);
        }
    }
}
