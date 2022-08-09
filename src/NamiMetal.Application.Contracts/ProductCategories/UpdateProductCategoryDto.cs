using System.ComponentModel.DataAnnotations;

namespace NamiMetal.Categories
{
    public class UpdateProductCategoryDto
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
