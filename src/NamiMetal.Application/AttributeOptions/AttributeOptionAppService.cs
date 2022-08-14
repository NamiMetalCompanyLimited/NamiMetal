using NamiMetal.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal.AttributeOptions
{
    public class AttributeOptionAppService :
        CrudAppService<
            AttributeOption,
            AttributeOptionDto,
            Guid,
            AttributeOptionDto,
            CreateAttributeOptionDto,
            UpdateAttributeOptionDto>,
        IAttributeOptionAppService
    {
        public AttributeOptionAppService(IRepository<AttributeOption, Guid> repository) : base(repository)
        {
            LocalizationResource = typeof(NamiMetalResource);
        }

    }
}
