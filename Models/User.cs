using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebForum.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsSilenced { get; set; } = false;
        public DateTime? SilenceStartTime { get; set; } = null;
        public DateTime? SilenceEndTime { get; set; } = null;
        public int Year { get; set; }

        public List<Message> Messages { get; set; }
        public List<Theme> Themes { get; set; }

        public User()
        {
            Messages = new List<Message>();
            Themes = new List<Theme>();
        }
    }
}
