using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.infrastructure.Configurations
{
    public class KursSessionConfig : IEntityTypeConfiguration<KursSession>
    {
        public void Configure(EntityTypeBuilder<KursSession> builder)
        {
            builder.ToTable("CourseSessions");

            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.StartDate).IsRequired();
            builder.Property(cs => cs.EndDate).IsRequired();

            builder.HasOne(cs => cs.Kurs)
                   .WithMany(c => c.Sessions)
                   .HasForeignKey(cs => cs.CourseId);

            builder.HasOne(cs => cs.Lärare)
                   .WithMany(t => t.Sessions)
                   .HasForeignKey(cs => cs.TeacherId);
        }
    }
}
