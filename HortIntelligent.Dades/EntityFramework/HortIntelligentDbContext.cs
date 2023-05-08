using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.EntityFramework.Seeding;
using HortIntelligent.Dades.Herlper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace HortIntelligent.Dades.EntityFramework
{
#pragma warning disable CS1591
    public class HortIntelligentDbContext : IdentityDbContext
    {
        public HortIntelligentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Medicio> Medicions { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Vegetal> Vegetals { get; set; }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(w => w.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                try
                {
                    entity.CurrentValues["IsDeleted"] = true;
                    entity.State = EntityState.Modified;
                }
                catch { }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(w => w.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                try
                {
                    var asd = entity.CurrentValues["IsDeleted"];
                    entity.CurrentValues["IsDeleted"] = true;
                    entity.State = EntityState.Modified;
                }
                catch { }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                var param = Expression.Parameter(entityType.ClrType, "entity");
                var prop = Expression.PropertyOrField(param, nameof(ISoftDelete.IsDeleted));
                var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);

                entityType.SetQueryFilter(entityNotDeleted);
            }


            SeedingHort.Seed(modelBuilder);
        }
    }
#pragma warning restore CS1591
}
