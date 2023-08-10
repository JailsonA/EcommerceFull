using Microsoft.EntityFrameworkCore;

namespace EcommerceFull.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
