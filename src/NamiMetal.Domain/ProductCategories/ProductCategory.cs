using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace NamiMetal.ProductCategories
{
    public class ProductCategory : Entity<Guid>, IFullAuditedObject
    {
        protected ProductCategory()
        {
            Childrens = new List<ProductCategory>();
        }

        public virtual Guid? ParentId { get; set; }

        public virtual ProductCategory Parent { get; set; }

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

        public virtual ICollection<ProductCategory> Childrens { get; set; }
    }
}
