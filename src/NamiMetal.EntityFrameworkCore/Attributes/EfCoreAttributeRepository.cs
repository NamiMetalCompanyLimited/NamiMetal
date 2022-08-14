using NamiMetal.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.Attributes
{
    public class EfCoreAttributeRepository : EfCoreRepository<
            NamiMetalDbContext,
            Attribute,
            Guid>,
        IAttributeRepository
    {
        public EfCoreAttributeRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
