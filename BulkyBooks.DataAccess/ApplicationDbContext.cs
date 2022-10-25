using BulkyBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooks.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; } 

        public DbSet<Product> Products { get; set; }
    }
}
