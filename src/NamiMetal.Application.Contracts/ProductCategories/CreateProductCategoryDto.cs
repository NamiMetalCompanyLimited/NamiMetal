using System.ComponentModel.DataAnnotations;

namespace NamiMetal.Categories
{
    public class CreateProductCategoryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
