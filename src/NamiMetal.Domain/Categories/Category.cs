using NamiMetal.Enums;
using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NamiMetal.Categories
{
    public class Category : Entity<Guid>, IFullAuditedObject
    {
        protected Category()
        {
        }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string Status { get; set; }

        public virtual Guid? CreatorId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual Guid? LastModifierId { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual Guid? DeleterId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }
}
