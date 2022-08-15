using NamiMetal.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Categories
{
    public class CategoryAppService :
        CrudAppService<
            Category,
            CategoryDto,
            Guid,
            SearchCategoryDto,
            CreateCategoryDto,
            UpdateCategoryDto>,
        //ApplicationService,
        ICategoryAppService
    {
        public CategoryAppService(IRepository<Category, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }

        //protected readonly ICategoryRepository _categoryRepository;

        //public CategoryAppService(ICategoryRepository categoryRepository)
        //{
        //    LocalizationResource = typeof(NamiMetalResource);
        //    _categoryRepository = categoryRepository;
        //}

        public override async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            if (input.ParentId.HasValue)
            {
                var parent = await GetAsync(input.ParentId.Value);
                input.Path = $"{parent.Path}/{parent.Id}";
            }
            else
            {
                input.Path = null;
            }

            return await base.CreateAsync(input);
        }

        public override async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            if (input.ParentId.HasValue)
            {
                var parent = await GetAsync(input.ParentId.Value);
                input.Path = $"{parent.Path}/{parent.Id}";
            }
            else
            {
                input.Path = null;
            }

            return await base.UpdateAsync(id, input);
        }

        //public override async Task<CategoryDto> GetAsync([NotNull] Guid id)
        // => ObjectMapper.Map<Category, CategoryDto>((await ReadOnlyRepository.WithDetailsAsync(x => x.Childrens))
        //     .Where(x => x.Id.Equals(id))
        //     .FirstOrDefault());

        public override async Task<PagedResultDto<CategoryDto>> GetListAsync(SearchCategoryDto input)
        {
            if (input.MaxResultCount <= 0)
            {
                input.MaxResultCount = 10;
            }

            //Check currentPage
            if (input.SkipCount < 0)
            {
                input.SkipCount = 0;
            }

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

            if (input.CreationTime.HasValue)
            {
                var start = input.CreationTime.Value.Date;
                var end = input.CreationTime.Value.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.CreationTime >= start && x.CreationTime <= end);
            }

            if (input.LastModificationTime.HasValue)
            {
                var start = input.LastModificationTime.Value.Date;
                var end = input.LastModificationTime.Value.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.LastModificationTime.HasValue && (x.LastModificationTime.Value >= start && x.LastModificationTime.Value <= end));
            }

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<CategoryDto>(
                totalCount,
                entityDtos
            );
        }
    }
}
