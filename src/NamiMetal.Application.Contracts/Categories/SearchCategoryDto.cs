using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Categories
{
    public class SearchCategoryDto : PagedAndSortedResultRequestDto
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool? Active { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new ValidationResult[0];
    }
}
