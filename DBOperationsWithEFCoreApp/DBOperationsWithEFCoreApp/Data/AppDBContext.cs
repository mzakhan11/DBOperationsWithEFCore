using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCoreApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
    }
}
