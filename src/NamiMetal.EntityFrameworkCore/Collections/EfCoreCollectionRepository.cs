using NamiMetal.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.Collections
{
    public class EfCoreCollectionRepository : EfCoreRepository<
            NamiMetalDbContext,
            Collection,
            Guid>,
        ICollectionRepository
    {
        public EfCoreCollectionRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
