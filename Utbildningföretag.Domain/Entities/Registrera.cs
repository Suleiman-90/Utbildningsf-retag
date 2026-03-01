using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Common;

namespace Utbildningföretag.Domain.Entities
{
    public class Registrera : BaseEntity
    {
        public Guid ParticipantId { get; private set; }
        public Deltagare Participant { get; private set; }

        public Guid CourseSessionId { get; private set; }
        public KursSession CourseSession { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        private Registrera() { }

        public Registrera(Guid participantId, Guid sessionId)
        {
            ParticipantId = participantId;
            CourseSessionId = sessionId;
            RegisteredAt = DateTime.UtcNow;
        }
    }
}
