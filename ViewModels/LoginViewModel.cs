using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        public string EmailOrLogin { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string ReturnUrl { get; set;}
    }
}
