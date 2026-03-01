using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.Interfaces;
using Utbildningsföretag.infrastructure.Persistance;

namespace Utbildningsföretag.infrastructure.Repositories
{
    public class RegistreraRepositori : IRegistrationRepository
    {
        private readonly Utbildningdbcontext _context;

        public RegistreraRepositori(Utbildningdbcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Registrera registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Guid participantId, Guid sessionId)
        {
            return await _context.Registrations.AnyAsync(r =>
                r.ParticipantId == participantId &&
                r.CourseSessionId == sessionId);
        }
    }
}
