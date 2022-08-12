using System;
using System.ComponentModel.DataAnnotations;

namespace NamiMetal.ProductCategories
{
    public class CreateProductCategoryDto
    {
        public Guid? ParentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
