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

namespace NamiMetal.Categories
{
    public class EfCoreCategoryRepository :
        EfCoreRepository<
            NamiMetalDbContext,
            Category,
            Guid>,
        ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
