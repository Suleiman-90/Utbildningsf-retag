using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Common;

namespace Utbildningföretag.Domain.Entities
{
    public class KursSession : BaseEntity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Guid CourseId { get; private set; }
        public Kurser Kurs { get; private set; }

        public Guid TeacherId { get; private set; }
        public Lärare Lärare { get; private set; }

        private readonly List<Registrera> _registrations = new();
        public IReadOnlyCollection<Registrera> Registrations => _registrations;

        private KursSession () { }

        public KursSession(
            Guid courseId,
            Guid teacherId,
            DateTime startDate,
            DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date");

            CourseId = courseId;
            TeacherId = teacherId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
