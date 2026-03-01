using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.Applikation.Interfaces
{
    public interface ISessionRepository
    {
        Task AddAsync(KursSession session);
        Task<KursSession?> GetByIdAsync(Guid id);
        
    }
}
