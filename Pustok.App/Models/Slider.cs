﻿using Pustok.App.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Pustok.App.Models
{
    public class Slider : AuditEntity
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public int Order { get; set; }
    }
}
