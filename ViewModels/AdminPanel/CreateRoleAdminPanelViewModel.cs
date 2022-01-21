using System.ComponentModel.DataAnnotations;

namespace WebForum.ViewModels.AdminPanel
{
    public class CreateRoleAdminPanelViewModel
    {
        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Allowed length from 4 to 32 characters")]
        public string Name { get; set; }
    }
}
