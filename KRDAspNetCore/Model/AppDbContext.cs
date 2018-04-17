using Microsoft.EntityFrameworkCore;

namespace KRDAspNetCore.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseSqlServer("Data Source=DESKTOP-UPN0PH9\\SQLEXPRESS;Initial Catalog=KRD;Integrated Security=True;Pooling=False;");
        //}
        public DbSet<User> Users { get; set; }

    }
}
