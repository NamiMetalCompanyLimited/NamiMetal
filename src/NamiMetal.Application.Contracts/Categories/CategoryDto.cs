using System;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
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
