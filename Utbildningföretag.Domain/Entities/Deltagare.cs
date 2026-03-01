using System;
using System.Collections.Generic;
using System.Text;
using Utbildningföretag.Domain.Common;

namespace Utbildningföretag.Domain.Entities
{
    public class Deltagare : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        private readonly List<Registrera> _registrations = new();
        public IReadOnlyCollection<Registrera> Registrations => _registrations;

        private Deltagare() { }

        public Deltagare (string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Participant name required");

            FullName = fullName;
            Email = email;
        }
    }
}
