using HortIntelligentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligentApi.EntityFramework.Configuracions
{
    public class SensorConfig : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.Property(prop => prop.Model)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(prop => prop.Nom)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
