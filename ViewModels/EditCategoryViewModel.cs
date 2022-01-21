using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;


namespace WebForum.ViewModels
{
    public class EditCategoryViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Required lenght from 3 to 100 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fill out the required field")]
        public bool IsHidden { get; set; } = false;

        public List<SectionViewModel> Sections { get; set; }
        
        public class SectionViewModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public bool IsHidden { get; set; }
            public Guid? CategoryId { get; set; }   
        }
        
    }
}
