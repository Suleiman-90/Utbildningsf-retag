using Utbildningföretag.Domain.Common;

namespace Utbildningföretag.Domain.Entities
{
    public class Lärare : BaseEntity
    {
        public string FullName { get; private set; }

        public string Email { get; private set; }

        private readonly List<KursSession> _sessions = new();

        public IReadOnlyCollection<KursSession> Sessions => _sessions;

        private Lärare() { }

        public Lärare(string fullName, string email)

        {

            if (string.IsNullOrWhiteSpace(fullName))

                throw new ArgumentException("Teacher name required");

            FullName = fullName;

            Email = email;

        }

    }
}

