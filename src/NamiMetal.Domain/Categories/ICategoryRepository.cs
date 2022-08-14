using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Categories
{
    public interface ICategoryRepository : IBasicRepository<Category, Guid>
    {
        Task<IQueryable<Category>> WithDetailsAsync();
    }
}
