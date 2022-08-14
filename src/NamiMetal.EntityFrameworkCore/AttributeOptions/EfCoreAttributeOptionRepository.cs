using NamiMetal.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.AttributeOptions
{
    public class EfCoreAttributeOptionRepository : EfCoreRepository<
            NamiMetalDbContext,
            AttributeOption,
            Guid>,
        IAttributeOptionRepository
    {
        public EfCoreAttributeOptionRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
