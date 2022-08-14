using NamiMetal.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.Collections
{
    public class CollectionAppService :
        CrudAppService<
            Collection,
            CollectionDto,
            Guid,
            SearchCollectionDto,
            CreateCollectionDto,
            UpdateCollectionDto>,
        ICollectionAppService
    {
        public CollectionAppService(IRepository<Collection, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }

        public override async Task<PagedResultDto<CollectionDto>> GetListAsync(SearchCollectionDto input)
        {
            if (input.MaxResultCount <= 0) input.MaxResultCount = 10;
            if (input.SkipCount < 0) input.SkipCount = 0;

            var query = await CreateFilteredQueryAsync(input);

            if (!input.Name.IsNullOrWhiteSpace()) query = query.Where(x => x.Name.Contains(input.Name));
            if (!input.Description.IsNullOrWhiteSpace()) query = query.Where(x => x.Description.Contains(input.Description));
            if (input.Active.HasValue) query = query.Where(x => x.Active.Equals(input.Active.Value));

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<CollectionDto>(
                totalCount,
                entityDtos
            );
        }
    }
}
