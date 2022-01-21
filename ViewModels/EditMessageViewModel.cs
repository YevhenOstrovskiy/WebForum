using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class EditMessageViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [MinLength(3, ErrorMessage = "Minimum length of field - 3 symbols")]
        [MaxLength(1000, ErrorMessage = "Maximum length of field - 1000 symbols")]
        public string Text { get; set; }
        public DateTime? CreatingTime { get; set; }
        public Guid? AuthorId { get; set; }
        public string AuthorUserName { get; set; }
        public Guid? ThemeId { get; set; }
        public string ThemeTitle { get; set; }
    }
}
