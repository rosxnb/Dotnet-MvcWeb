using Microsoft.EntityFrameworkCore;
using MvcWeb.Models;

namespace MvcWeb.Data
{
    public class MySqlDb : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public MySqlDb(DbContextOptions<MySqlDb> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }
}
