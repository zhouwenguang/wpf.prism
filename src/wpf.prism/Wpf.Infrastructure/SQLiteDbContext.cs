
using Microsoft.EntityFrameworkCore;
using Wpf.Models;

namespace Wpf.Infrastructure
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=my.db");
    }

}
