using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Incorrect address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Allowed length from 4 to 16 characters")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Fill out the required field")]
        [MinLength(6, ErrorMessage ="Minimum lenght - 6 symbols")]
        [DataType(DataType.Password, ErrorMessage = "Insufficiently strong password")]
        public string Password { get; set;}

        [Required(ErrorMessage = "Fill out the required field")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set;}

    }
}
