using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Collections
{
    public class CollectionDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
