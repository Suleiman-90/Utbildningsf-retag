using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.infrastructure.Configurations
{
    public class KursConfig : IEntityTypeConfiguration<Kurser>
    {
        public void Configure(EntityTypeBuilder<Kurser> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);
        }
    }
}
