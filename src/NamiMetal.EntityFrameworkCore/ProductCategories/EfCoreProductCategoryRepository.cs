using NamiMetal.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.ProductCategories
{
    public class EfCoreProductCategoryRepository :
        EfCoreRepository<
            NamiMetalDbContext,
            ProductCategory,
            Guid>,
        IProductCategoryRepository
    {
        public EfCoreProductCategoryRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
