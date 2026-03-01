using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.Applikation.Interfaces
{
    public interface IRegistrationRepository
    {
        Task AddAsync(Registrera registration);
        Task<bool> ExistAsync(Guid id,Guid SessionId);
    }
}
