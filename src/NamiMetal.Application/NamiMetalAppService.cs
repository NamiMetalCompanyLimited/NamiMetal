using NamiMetal.Domain;
using NamiMetal.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace NamiMetal
{
    /* Inherit your application services from this class.
     */
    public abstract class NamiMetalAppService : ApplicationService
    {
        protected NamiMetalAppService()
        {
            LocalizationResource = typeof(NamiMetalResource);
        }
    }
    public abstract class BaseCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        : CrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TGetOutputDto : IEntityDto<TKey>
        where TGetListOutputDto : IEntityDto<TKey>
        //where TKey : Type
    {
        public BaseCrudAppService(IRepository<TEntity, TKey> repository) : base(repository) { }

        public async Task CUDChildren<T_DtoDetail, T_EntityDetail>(TKey ParentRelationshipId, IBasicRepository<T_EntityDetail> _Repository, List<T_DtoDetail> InDtos, List<T_EntityDetail> InEntitys) where T_DtoDetail
            : EntityDto<TKey>
            where T_EntityDetail : class, IChildrenDomainEntity<TKey>
        {
            if (InDtos == null) InDtos = new List<T_DtoDetail>();
            if (InEntitys == null) InEntitys = new List<T_EntityDetail>();
            //Remove
            foreach (var chil in InEntitys)
            {
                if (!InDtos.Any(c => c.Id.Equals(chil.Id))) await _Repository.DeleteAsync(chil);
            }
            //update/insert new 
            foreach (var chil in InDtos)
            {
                var oldChil = InEntitys.Where(c => c.Id.Equals(chil.Id)/*&& (c.Id as Guid) != Guid.Empty*/).SingleOrDefault();
                if (oldChil != null)
                {
                    // Update Old
                    ObjectMapper.Map(chil, oldChil);
                    oldChil.SetParentRelationship(ParentRelationshipId);
                    if (oldChil is IHasModificationTime) (oldChil as IHasModificationTime).LastModificationTime = DateTime.Now;
                    await _Repository.UpdateAsync(oldChil);
                }
                else
                {
                    var createValue = ObjectMapper.Map<T_DtoDetail, T_EntityDetail>(chil);
                    createValue.SetParentRelationship(ParentRelationshipId);
                    //if (oldChil is IHasCreationTime) (oldChil as IHasCreationTime).CreationTime = DateTime.Now;
                    createValue = await _Repository.InsertAsync(createValue);
                    chil.Id = createValue.Id;
                }
            }
        }
    }
}