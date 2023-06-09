﻿using HortIntelligent.Dades.Entitats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HortIntelligent.Dades.EntityFramework.Configuracions
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
