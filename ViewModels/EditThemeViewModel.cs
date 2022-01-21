using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class EditThemeViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Required length of field - from 6 to 100 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fill out required field")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Required length of field - from 10 to 1000 symbols")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        public bool IsHidden { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        public bool IsClosed  { get; set; }
        public Guid? AuthorId { get; set; }
        public string AuthorUserName { get; set; }
    }
}
