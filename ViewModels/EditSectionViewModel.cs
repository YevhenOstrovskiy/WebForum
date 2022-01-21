using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class EditSectionViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Required length of field - from 3 to 100 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Fill out the required field")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Required length of field - from 3 to 250 symbols")]
        private string Description { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        public bool IsHidden { get; set; }

    }
}
