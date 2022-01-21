using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class UserEditProfileViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Allowed length from 4 to 16 characters")]
        public string Login { get; set; }

        [MaxLength(64, ErrorMessage = "Maximum length - 64 symbols")]
        public string Status { get; set; }
    }
}
