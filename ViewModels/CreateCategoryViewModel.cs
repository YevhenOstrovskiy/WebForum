using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Required length - from 3 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        public bool IsHidden { get; set; } = false;
        
    }
}
