﻿using System;

namespace WebForum.ViewModels.AdminPanel
{
    public class ReportsAdminPanelViewModel
    {
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Type { get; set; }
        public bool IsChecked { get; set; }
        public Guid InintiatorId { get; set; }
        public string Initiatorname { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
    }
}
