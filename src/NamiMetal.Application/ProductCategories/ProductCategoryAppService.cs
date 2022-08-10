using JetBrains.Annotations;
using NamiMetal.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.ProductCategories
{
    public class ProductCategoryAppService :
        CrudAppService<
            ProductCategory,
            ProductCategoryDto,
            Guid,
            PagedResultRequestDto,
            CreateProductCategoryDto,
            UpdateProductCategoryDto>,
        //ApplicationService,
        IProductCategoryAppService
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }

        //protected readonly IProductCategoryRepository _productCategoryRepository;

        //public ProductCategoryAppService(IProductCategoryRepository productCategoryRepository)
        //{
        //    LocalizationResource = typeof(NamiMetalResource);
        //    _productCategoryRepository = productCategoryRepository;
        //}

        public override async Task<ProductCategoryDto> GetAsync([NotNull] Guid id)
        {
            return ObjectMapper.Map<ProductCategory, ProductCategoryDto>((await ReadOnlyRepository.WithDetailsAsync(x => x.Childrens)).FirstOrDefault());
        }
    }
}
