using HortIntelligentApi.Domini.Entitats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligentApi.Datos.EntityFramework.Configuracions
{
    public class VegetalConfig : IEntityTypeConfiguration<Vegetal>
    {
        public void Configure(EntityTypeBuilder<Vegetal> builder)
        {
            builder.Property(prop => prop.Nom)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(prop => prop.HumitatMaxima)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.HumitatMinima)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.HumitatOptima)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.TemperaturaMaxima)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.TemperaturaMinima)
                .HasPrecision(precision: 5, scale: 2);

            builder.Property(prop => prop.TemperaturaOptima)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
