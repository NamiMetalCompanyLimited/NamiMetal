using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Attributes
{
    public class AttributeDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<AttributeOptions.AttributeOptionDto> Childrens { get; set; }
    }
    public class CreateAttributeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<AttributeOptions.CreateAttributeOptionDto> Childrens { get; set; }
    }
    public class UpdateAttributeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<AttributeOptions.UpdateAttributeOptionDto> Childrens { get; set; }
    }

    public class SearchAttributeDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new ValidationResult[0];
    }
}
