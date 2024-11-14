using Microsoft.EntityFrameworkCore;

namespace e_commerce.Models
{
    public class DoorStepDonutsDbContext : DbContext
    {
        public DoorStepDonutsDbContext(DbContextOptions<DoorStepDonutsDbContext> options) : base(options) { }

        public DbSet<Donut>? Donuts { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db");

            }
        }


    }

}
