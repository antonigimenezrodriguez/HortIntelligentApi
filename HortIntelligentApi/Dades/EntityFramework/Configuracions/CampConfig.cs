using HortIntelligentApi.Domini.Entitats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligentApi.Dades.EntityFramework.Configuracions
{
    public class CampConfig : IEntityTypeConfiguration<Camp>
    {
        public void Configure(EntityTypeBuilder<Camp> builder)
        {
            builder.Property(prop => prop.Localitzacio)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
