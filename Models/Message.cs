using System;

namespace WebForum.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatingTime { get; set; }

        public User Author { get; set; }
        public Theme Theme { get; set; }
    }
}
