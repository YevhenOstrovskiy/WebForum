using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForum.Models
{
    // It`s helping class for organization connection MANY to MANY
    // for tables Themes and Sections
    [Table("ThemeSections")]
    public class ThemeSection
    {
        public Guid Id { get; set; }
        public Theme Theme { get; set; }
        public Section Section { get; set; }
    }
}
