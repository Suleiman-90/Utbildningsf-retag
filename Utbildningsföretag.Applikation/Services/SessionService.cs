using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.DTOs;
using Utbildningsföretag.Applikation.Interfaces;

namespace Utbildningsföretag.Applikation.Services
{
    public class SessionService
    {
        private readonly ISessionRepository _repo;

        public SessionService(ISessionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateSessionAsync(CreateSessionDto dto)
        {
            var session = new KursSession(
                dto.CourseId,
                dto.TeacherId,
                dto.StartDate,
                dto.EndDate);

            await _repo.AddAsync(session);
            return session.Id;
        }
    }
}
