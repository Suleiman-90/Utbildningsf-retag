using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.Interfaces;
using Utbildningsföretag.infrastructure.Persistance;

namespace Utbildningsföretag.infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly Utbildningdbcontext _context;

        public SessionRepository(Utbildningdbcontext context)

        {

            _context = context;

        }

        public async Task AddAsync(KursSession session)

        {

            _context.CourseSessions.Add(session);

            await _context.SaveChangesAsync();

        }

        public async Task<KursSession?> GetByIdAsync(Guid id)

        {

            return await _context.CourseSessions

                .Include(s => s.Registrations)

                .Include(s => s.Kurs)

                .Include(s => s.Lärare)

                .FirstOrDefaultAsync(s => s.Id == id);

        }

    }
}
