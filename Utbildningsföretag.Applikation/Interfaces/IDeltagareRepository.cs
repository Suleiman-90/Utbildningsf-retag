using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;

namespace Utbildningsföretag.Applikation.Interfaces
{
    public interface IDeltagareRepository   
    {
        Task AddAsync(Deltagare participant);

        Task<Deltagare?> GetByIdAsync(Guid id);

    }
}
