using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.infrastructure.Persistance
{
    public class Utbildningdbcontext : DbContext
    {
        public Utbildningdbcontext(DbContextOptions<Utbildningdbcontext> options)
        : base(options) { }

        public DbSet<Kurser> Courses => Set<Kurser>();
        public DbSet<Lärare> Teachers => Set<Lärare>();
        public DbSet<Deltagare> Participants => Set<Deltagare>();
        public DbSet<KursSession> CourseSessions => Set<KursSession>();
        public DbSet<Registrera> Registrations => Set<Registrera>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(Utbildningdbcontext).Assembly);
        }
    }
}
