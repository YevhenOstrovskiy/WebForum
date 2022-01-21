using System.ComponentModel.DataAnnotations;
using System;

namespace WebForum.ViewModels.AdminPanel
{
    public class RoleEditAdminPanelViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "fill out the required field")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Required length - from 4 to 32 symbols ")]
        public string Name { get; set; }
    }
}
