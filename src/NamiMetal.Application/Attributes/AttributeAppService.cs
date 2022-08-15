using NamiMetal.Domain;
using NamiMetal.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace NamiMetal.Attributes
{
    public class AttributeAppService : CrudAppService<
            Attribute,
            AttributeDto,
            AttributeDto,
            Guid,
            SearchAttributeDto,
            CreateAttributeDto,
            UpdateAttributeDto>,
        IAttributeAppService
    {
        private readonly AttributeOptions.IAttributeOptionRepository _attributeOptionRepository;
        public AttributeAppService(
            IRepository<Attribute, Guid> repository,
            AttributeOptions.IAttributeOptionRepository attributeOptionRepository
        ) : base(repository)
        {
            _attributeOptionRepository = attributeOptionRepository;
        }
        protected override async Task<IQueryable<Attribute>> CreateFilteredQueryAsync(SearchAttributeDto input)
        {
            if (input.MaxResultCount <= 0) input.MaxResultCount = 10;
            if (input.SkipCount < 0) input.SkipCount = 0;
            var rt = await Repository.WithDetailsAsync(c => c.Childrens);
            return rt
            .WhereIf(
               condition: input.Active.HasValue,
               predicate: e => e.Active == input.Active.Value
           )
           .WhereIf(
               condition: !string.IsNullOrWhiteSpace(input.Name),
               predicate: e => e.Name.Contains(input.Name)
           )
           .WhereIf(
               condition: !string.IsNullOrWhiteSpace(input.Description),
               predicate: e => e.Description.Contains(input.Description)
           )
           ;
        }

        public override async Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto input)
        {
            var oldObj = await GetAsync(id);
            if (oldObj == null)
            {
                throw new UserFriendlyException($"Không tìm thấy Attribute {input?.Name}!");
            }
            else
            {
                var adds = ObjectMapper.Map<List<AttributeOptions.UpdateAttributeOptionDto>, List<AttributeOptions.AttributeOption>>(input.Childrens.Where(c => c.Id == Guid.Empty).ToList());
                var upds = new List<AttributeOptions.AttributeOption>();
                foreach (var chil in input.Childrens ?? new List<AttributeOptions.UpdateAttributeOptionDto>())
                {
                    if (chil.Id != Guid.Empty)
                    {
                        var old = oldObj.Childrens.FirstOrDefault(o => o.Id == chil.Id);
                        old = ObjectMapper.Map(chil, old);
                        upds.Add(ObjectMapper.Map<AttributeOptions.AttributeOptionDto, AttributeOptions.AttributeOption>(old));
                    }
                }

                var UpDto = ObjectMapper.Map<AttributeDto, UpdateAttributeDto>(oldObj);
                UpDto.Childrens = null;
                var result = await base.UpdateAsync(id, UpDto);
                foreach (var upd in upds)
                {
                    await _attributeOptionRepository.UpdateAsync(upd);
                }
                foreach (var ins in adds)
                {
                    ins.SetParentRelationship(id);
                    await _attributeOptionRepository.InsertAsync(ins);
                }
                return await GetAsync(id);

                //ObjectMapper.Map(input, oldObj);
                //var updOldObj = await _attributeRepository.UpdateAsync(oldObj);
                ////var rt = await GetAsync(id);
                ////return rt;
                //return ObjectMapper.Map<Attribute, AttributeDto>(updOldObj);
            }

        }
        //public async override Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto input)
        //{
        //    ////var srhOld = await GetAsync(id);
        //    ////var oldObj = ObjectMapper.Map<AttributeDto, Attribute>(srhOld);
        //    //var oldObj = await Repository.FindAsync(id, true);
        //    //if (oldObj == null)
        //    //{
        //    //    throw new UserFriendlyException($"Không tìm thấy Attribute {input?.Name}!");
        //    //}
        //    //else
        //    //{
        //    //    await CUDChildren(oldObj.Id, _attributeOptionRepository, input.Childrens, oldObj.Childrens);
        //    //    ObjectMapper.Map(input, oldObj);
        //    //    var updOldObj = await _attributeRepository.UpdateAsync(oldObj);
        //    //    //var rt = await GetAsync(id);
        //    //    //return rt;
        //    //    return ObjectMapper.Map<Attribute, AttributeDto>(updOldObj);
        //    //}
        //    //var queryable = await Repository.GetQueryableAsync();

        //    //var query = queryable.AsNoTracking()
        //    //    .Where(x => x.Price > 10)
        //    //    .Select(x => x.Name);


        //    //var entity = await Repository.GetAsync(id);
        //    //entity = ObjectMapper.Map<UpdateAttributeDto, Attribute>(input);

        //    //var upd = await Repository.UpdateAsync(entity);
        //    //return ObjectMapper.Map<Attribute, AttributeDto>(upd);

        //    using (var unitOfWork = _unitOfWorkManager.Begin(isTransactional: true))
        //    {
        //        try
        //        {
        //            var trans = await base.UpdateAsync(id, input);
        //            await unitOfWork.SaveChangesAsync();
        //            return trans;
        //        }
        //        catch (Exception)
        //        {
        //            await unitOfWork.RollbackAsync();
        //            throw;
        //        }
        //    }
        //}
    }
}
