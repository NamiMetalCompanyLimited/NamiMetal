using System;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Attributes
{
    public interface IAttributeRepository : IBasicRepository<Attribute, Guid>
    {
    }
}
