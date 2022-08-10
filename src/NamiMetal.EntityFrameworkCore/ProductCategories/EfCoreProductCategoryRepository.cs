using Microsoft.EntityFrameworkCore;
using NamiMetal.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
