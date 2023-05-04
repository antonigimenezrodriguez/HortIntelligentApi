using HortIntelligentApi.Dades.EntityFramework.Seeding;
using HortIntelligentApi.Domini.Entitats;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HortIntelligentApi.Dades.EntityFramework
{
    public class HortIntelligentDbContext : DbContext
    {
        public HortIntelligentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Medicio> Medicions { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Vegetal> Vegetals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingHort.Seed(modelBuilder);
        }
    }
}
