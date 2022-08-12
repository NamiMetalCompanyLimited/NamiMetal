using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.ProductCategories
{
    public class ProductCategoryDto : EntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public ProductCategoryDto Parent { get; set; }
        public ICollection<ProductCategoryDto> Childrens { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
