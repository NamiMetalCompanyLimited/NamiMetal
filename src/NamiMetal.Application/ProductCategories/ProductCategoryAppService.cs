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
            SearchProductCategoryDto,
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
            => ObjectMapper.Map<ProductCategory, ProductCategoryDto>((await ReadOnlyRepository.WithDetailsAsync(x => x.Childrens))
                .FirstOrDefault());

        public override async Task<PagedResultDto<ProductCategoryDto>> GetListAsync(SearchProductCategoryDto input)
        {
            var query = await CreateFilteredQueryAsync(input);

            if (!input.Name.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Name.Contains(input.Name));
            }

            if (!input.Description.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Description.Contains(input.Description));
            }

            if (input.Active.HasValue)
            {
                query = query.Where(x => x.Active.Equals(input.Active.Value));
            }

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<ProductCategoryDto>(
                totalCount,
                entityDtos
            );
        }
    }
}
