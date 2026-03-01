using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.DTOs;
using Utbildningsföretag.Applikation.Interfaces;

namespace Utbildningsföretag.Applikation.Services
{
    public class DeltagareService
    {
        private readonly IDeltagareRepository _repo;

        public DeltagareService(IDeltagareRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateParticipantAsync(CreateDeltagareDto dto)
        {
            var participant = new Deltagare(dto.FullName, dto.Email);
            await _repo.AddAsync(participant);
            return participant.Id;
        }
    }
}
