using NamiMetal.Localization;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Categories
{
    public class ProductCategoryAppService :
        CrudAppService<
            ProductCategory,
            ProductCategoryDto,
            Guid,
            PagedResultRequestDto,
            CreateProductCategoryDto,
            UpdateProductCategoryDto>,
        IProductCategoryAppService
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }
    }
}
