using Microsoft.EntityFrameworkCore;
using MvcWeb.Category;

namespace Mvc.Data
{
    public class MySqlDb : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public MySqlDb(DbContextOptions<MySqlDb> options)
            : base(options)
        { }
    }
}
