using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.ProductCategories
{
    public interface IProductCategoryRepository : IBasicRepository<ProductCategory, Guid>
    {
        Task<IQueryable<ProductCategory>> WithDetailsAsync();
    }
}
