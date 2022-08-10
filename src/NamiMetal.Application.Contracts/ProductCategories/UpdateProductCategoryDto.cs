using System;
using System.ComponentModel.DataAnnotations;

namespace NamiMetal.ProductCategories
{
    public class UpdateProductCategoryDto
    {
        public Guid ParentId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
