using HortIntelligentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligentApi.EntityFramework.Configuracions
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
