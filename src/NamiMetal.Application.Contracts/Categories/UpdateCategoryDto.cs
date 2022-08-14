﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NamiMetal.Categories
{
    public class UpdateCategoryDto
    {
        public Guid? ParentId { get; set; }

        [StringLength(1000)]
        public string Path { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}