using HortIntelligent.Dades.Entitats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligent.Dades.EntityFramework.Configuracions
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
