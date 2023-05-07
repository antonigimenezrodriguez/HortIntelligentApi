using HortIntelligent.Dades.Entitats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HortIntelligent.Dades.EntityFramework.Configuracions
{
    public class MedicioConfig : IEntityTypeConfiguration<Medicio>
    {
        public void Configure(EntityTypeBuilder<Medicio> builder)
        {
            builder.HasKey(prop => new { prop.DataHora, prop.SensorId, prop.CampId, prop.VegetalId });

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Valor)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
