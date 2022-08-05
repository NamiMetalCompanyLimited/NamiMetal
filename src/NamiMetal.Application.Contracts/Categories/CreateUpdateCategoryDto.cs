using NamiMetal.Enums;
using System.ComponentModel.DataAnnotations;

namespace NamiMetal.Categories
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
