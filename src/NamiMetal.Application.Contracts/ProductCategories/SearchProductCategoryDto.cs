using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.ProductCategories
{
    public class SearchProductCategoryDto : PagedAndSortedResultRequestDto
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool? Active { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var result = base.Validate(validationContext);
            return new ValidationResult[0];
        }
    }
}
