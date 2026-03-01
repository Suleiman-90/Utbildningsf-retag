using Utbildningföretag.Domain.Common;

namespace Utbildningföretag.Domain.Entities
{
    public class Kurser : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        private readonly List<KursSession> _sessions = new();
        public IReadOnlyCollection<KursSession> Sessions => _sessions;

        private Kurser() { } // EF Core

        public Kurser(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Course title is required");

            Title = title;
            Description = description;
        }

        public void AddSession(KursSession session)
        {
            _sessions.Add(session);
        }
    }
}
