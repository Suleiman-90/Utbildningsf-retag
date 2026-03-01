using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.infrastructure.Configurations
{
    public class RegistreraConfig : IEntityTypeConfiguration<Registrera>
    {
        public void Configure(EntityTypeBuilder<Registrera> builder)
        {
            builder.ToTable("Registrationer");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RegisteredAt)
                   .IsRequired();

            builder.HasOne(r => r.Participant)
                   .WithMany(p => p.Registrations)
                   .HasForeignKey(r => r.ParticipantId);

            builder.HasOne(r => r.CourseSession)
                   .WithMany(cs => cs.Registrations)
                   .HasForeignKey(r => r.CourseSessionId);

            builder.HasIndex(r => new { r.ParticipantId, r.CourseSessionId })
                   .IsUnique(); // prevents duplicate registrations
        }
    }
}
