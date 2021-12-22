using Microsoft.EntityFrameworkCore;
using web_api.Entities;

namespace web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<appUser>Users { get; set; }
    }
}