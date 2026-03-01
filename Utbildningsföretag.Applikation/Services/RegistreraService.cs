using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.DTOs;
using Utbildningsföretag.Applikation.Interfaces;

namespace Utbildningsföretag.Applikation.Services
{
    public class RegistreraService
    {
        private readonly IRegistrationRepository _repo;

        public RegistreraService(IRegistrationRepository repo)

        {

            _repo = repo;

        }

        public async Task RegisterAsync(RegistreraDeltagareDto dto)

        {

            var exists = await _repo.ExistAsync(

                dto.ParticipantId,

                dto.CourseSessionId);

            if (exists)

                throw new InvalidOperationException("Already registered");

            var registration = new Registrera(

                dto.ParticipantId,

                dto.CourseSessionId);

            await _repo.AddAsync(registration);

        }

    }
}
