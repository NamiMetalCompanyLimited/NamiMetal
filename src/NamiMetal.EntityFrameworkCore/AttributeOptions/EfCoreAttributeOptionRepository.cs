using NamiMetal.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
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
        public override Task<AttributeOption> UpdateAsync(AttributeOption entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var rt = base.UpdateAsync(entity, autoSave, cancellationToken);
            return rt;
        }
    }
}
