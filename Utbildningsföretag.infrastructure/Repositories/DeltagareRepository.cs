using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.Interfaces;
using Utbildningsföretag.infrastructure.Persistance;

namespace Utbildningsföretag.infrastructure.Repositories
{
    public class DeltagareRepository : IDeltagareRepository
    {
        private readonly Utbildningdbcontext _context;

        public DeltagareRepository(Utbildningdbcontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Deltagare participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
        }

        public async Task<Deltagare?> GetByIdAsync(Guid id)
        {
            return await _context.Participants
                .Include(p => p.Registrations)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
