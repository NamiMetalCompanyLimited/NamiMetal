using System;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.AttributeOptions
{
    public class AttributeOptionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
    public class CreateAttributeOptionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
    public class UpdateAttributeOptionDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
