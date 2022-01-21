using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class CreateSectionViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Required lenght from 3 to 100 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Required lenght from 3 to 500 symbols")]
        public string Description { get; set; }
        public bool IsHidden { get; set; } = false;
    }
}
