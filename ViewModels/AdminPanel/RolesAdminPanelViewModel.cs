using System;

namespace WebForum.ViewModels.AdminPanel
{
    public class RolesAdminPanelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UsersCount { get; set; }
    }
}
