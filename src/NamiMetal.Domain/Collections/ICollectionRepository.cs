using System;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Collections
{
    public interface ICollectionRepository : IBasicRepository<Collections.Collection, Guid>
    {
    }
}
