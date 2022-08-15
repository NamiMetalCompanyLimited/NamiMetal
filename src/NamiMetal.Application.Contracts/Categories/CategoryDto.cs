using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Categories
{
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public CategoryDto Parent { get; set; }
        public string Path { get; set; }
        public ICollection<CategoryDto> Childrens { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
