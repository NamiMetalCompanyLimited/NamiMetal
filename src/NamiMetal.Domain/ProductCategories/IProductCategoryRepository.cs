using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.ProductCategories
{
    public interface IProductCategoryRepository : IBasicRepository<ProductCategory, Guid>
    {
        Task<IQueryable<ProductCategory>> WithDetailsAsync();
    }
}
