using System;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.AttributeOptions
{
    public interface IAttributeOptionRepository : IBasicRepository<AttributeOption, Guid>
    {
    }
}
