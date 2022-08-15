using Dapper.Contrib.Extensions;
using NamiMetal.Domain;
using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace NamiMetal.AttributeOptions
{
    public class AttributeOption : FullAuditedEntity<Guid>, IFullAuditedObject, IChildrenDomainEntity<Guid>
    {
        protected AttributeOption()
        {
        }
        public Guid AttributeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //[Write(false)]
        public virtual Attributes.Attribute Attribute { get; set; }

        public void SetId(Guid id) => Id = id;
        public void SetParentRelationship(Guid id) => AttributeId = id;
    }
}
