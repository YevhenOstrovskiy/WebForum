using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Write your message")]
        [MinLength(3, ErrorMessage = "Minimum length - 3 symbols")]
        public string Text { get; set; }
    }
}
