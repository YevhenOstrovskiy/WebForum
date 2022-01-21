using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [MinLength(6, ErrorMessage = "Minimum lenght - 6 symbols")]
        [DataType(DataType.Password, ErrorMessage = "Insufficiently strong password")]
        public string NewPassword { get; set;}
    }
}
