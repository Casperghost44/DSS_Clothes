using DSS_Clothes.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS_Clothes.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }
        public DbSet<Clothe> Clothes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
