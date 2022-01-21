﻿using System;
using System.Collections.Generic;

namespace WebForum.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsHidden { get; set; } = false;
        public List<Section> Sections { get; set; }
        public Category()
        {
            Sections = new List<Section>();
        }
    }
}
