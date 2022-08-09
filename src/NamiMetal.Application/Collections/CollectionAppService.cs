using NamiMetal.Localization;
using System;
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
            PagedResultRequestDto,
            CreateCollectionDto,
            UpdateCollectionDto>,
        ICollectionAppService
    {
        public CollectionAppService(IRepository<Collection, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }
    }
}
