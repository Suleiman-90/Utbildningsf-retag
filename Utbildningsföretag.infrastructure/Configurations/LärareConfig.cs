using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.infrastructure.Configurations
{
    public class LärareConfig : IEntityTypeConfiguration<Lärare>
    {
        public void Configure(EntityTypeBuilder<Lärare> builder)

        {

            builder.ToTable("Teachers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName)

                   .IsRequired()

                   .HasMaxLength(150);

            builder.Property(t => t.Email)

                   .IsRequired()

                   .HasMaxLength(150);

        }

    }
}
