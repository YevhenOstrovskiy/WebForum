using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class NewThemeViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Required length of field - from 10 to 100 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fill out the requirement field")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Required length of field - from 10 to 1000 symbols")]
        public string Description { get; set; }

        public Guid? sectionId { get; set; }
        public string SectionTitle { get; set; }
    }
}
