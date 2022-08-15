using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace NamiMetal.Collections
{
    public class Collection : FullAuditedEntity<Guid>, IFullAuditedObject
    {
        protected Collection() { }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
