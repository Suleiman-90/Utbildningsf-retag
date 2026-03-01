using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.DTOs;

namespace Utbildningsföretag.Applikation.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Kurser course);
        Task<Kurser?> GetByIdAsync(Guid id);
        Task<List<Kurser>> GetAllAsync();
    }
}
