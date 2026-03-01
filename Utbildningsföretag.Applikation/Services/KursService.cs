using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Entities;
using Utbildningsföretag.Applikation.DTOs;
using Utbildningsföretag.Applikation.Interfaces;

namespace Utbildningsföretag.Applikation.Services
{
    public class KursService
    {
        private readonly ICourseRepository _repo;

        public KursService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateCourseAsync(CreateKursDto dto)
        {
            var course = new Kurser(dto.Title, dto.Description);
            await _repo.AddAsync(course);
            return course.Id;
        }

        public Task<List<Kurser>> GetCoursesAsync()
            => _repo.GetAllAsync();
    }
}
