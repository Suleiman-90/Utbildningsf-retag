using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.Interfaces;
using Utbildningsföretag.infrastructure.Persistance;

namespace Utbildningsföretag.infrastructure.Repositories
{
    public class KursRepository : ICourseRepository
    {
        private readonly Utbildningdbcontext _context;

        public KursRepository(Utbildningdbcontext context)

        {

            _context = context;

        }

        public async Task AddAsync(Kurser course)

        {

            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

        }

        public async Task<Kurser?> GetByIdAsync(Guid id)

        {

            return await _context.Courses

                .Include(c => c.Sessions)

                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<List<Kurser>> GetAllAsync()

        {

            return await _context.Courses.ToListAsync();

        }

    }
}
