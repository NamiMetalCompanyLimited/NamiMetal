using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace NamiMetal.Attributes
{
    public class Attribute : FullAuditedEntity<Guid>, IFullAuditedObject
    {
        protected Attribute()
        {
            Childrens = new List<AttributeOptions.AttributeOption>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //[Write(false)]
        public virtual List<AttributeOptions.AttributeOption> Childrens { get; set; }

    }
}
