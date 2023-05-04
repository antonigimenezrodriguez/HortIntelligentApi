using HortIntelligentApi.EntityFramework.Seeding;
using HortIntelligentApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HortIntelligentApi.EntityFramework
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
