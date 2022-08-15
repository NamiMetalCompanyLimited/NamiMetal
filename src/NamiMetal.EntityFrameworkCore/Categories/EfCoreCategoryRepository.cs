﻿using NamiMetal.EntityFrameworkCore;
using System;
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
