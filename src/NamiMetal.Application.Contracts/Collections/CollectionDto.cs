using System;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Collections
{
    public class CollectionDto : EntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Active { get; set; }

        public virtual Guid? CreatorId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual Guid? LastModifierId { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual Guid? DeleterId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }
}
