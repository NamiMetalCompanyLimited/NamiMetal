using Microsoft.EntityFrameworkCore;
using NamiMetal.AttributeOptions;
using NamiMetal.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.Attributes
{
    public class EfCoreAttributeRepository : EfCoreRepository<
            NamiMetalDbContext,
            Attribute,
            Guid>,
        IAttributeRepository
    {
        public EfCoreAttributeRepository(IDbContextProvider<NamiMetalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //public override async Task<Attribute> UpdateAsync(Attribute entity, bool autoSave = false, CancellationToken cancellationToken = default)
        //{
        //    var old = await GetAsync(entity.Id);
        //    old.Name= entity.Name;
        //    var rt = await base.UpdateAsync(old, autoSave, cancellationToken);
        //    return rt;
        //}
        //public override async Task<Attribute> UpdateAsync(Attribute entity, bool autoSave = false, CancellationToken cancellationToken = default)
        //{
        //    var db = await GetDbContextAsync();
        //    var existingParent = db.Attributes.Where(p => p.Id == entity.Id)
        //        .Include(p => p.Childrens)
        //        .SingleOrDefault();
        //    if (existingParent == null) throw new Exception("Null parrent!");
        //    // Update parent
        //    db.Entry(existingParent).CurrentValues.SetValues(entity);

        //    // Delete children
        //    foreach (var existingChild in existingParent.Childrens)
        //    {
        //        if (!entity.Childrens.Any(c => c.Id == existingChild.Id)) db.AttributeOptions.Remove(existingChild);
        //    }

        //    // Update and Insert children
        //    foreach (var childModel in entity.Childrens)
        //    {
        //        var existingChild = existingParent.Childrens
        //            .Where(c => c.Id == childModel.Id && c.Id != Guid.Empty)
        //            .SingleOrDefault();

        //        if (existingChild != null)
        //            // Update child
        //            db.Entry(existingChild).CurrentValues.SetValues(childModel);
        //        else
        //        {

        //            //// Insert child
        //            //var newChild =  new AttributeOption
        //            //{

        //            //};
        //            existingParent.Childrens.Add(childModel);
        //        }
        //    }

        //    db.SaveChanges();
        //    return existingParent;
        //}

        //public async override Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto input)
        //{
        //    //var srhOld = await GetAsync(id);
        //    //var oldObj = ObjectMapper.Map<AttributeDto, Attribute>(srhOld);
        //    var oldObj = await Repository.FindAsync(id, true);
        //    if (oldObj == null)
        //    {
        //        throw new UserFriendlyException($"Không tìm thấy Attribute {input?.Name}!");
        //    }
        //    else
        //    {
        //        await CUDChildren(oldObj.Id, _attributeOptionRepository, input.Childrens, oldObj.Childrens);
        //        ObjectMapper.Map(input, oldObj);
        //        var updOldObj = await _attributeRepository.UpdateAsync(oldObj);
        //        //var rt = await GetAsync(id);
        //        //return rt;
        //        return ObjectMapper.Map<Attribute, AttributeDto>(updOldObj);
        //    }
        //    var queryable = await Repository.GetQueryableAsync();

        //    var query = queryable.AsNoTracking()
        //        .Where(x => x.Price > 10)
        //        .Select(x => x.Name);


        //    var entity = await Repository.GetAsync(id);
        //    entity = ObjectMapper.Map<UpdateAttributeDto, Attribute>(input);

        //    var upd = await Repository.UpdateAsync(entity);
        //    return ObjectMapper.Map<Attribute, AttributeDto>(upd);

        //}


    }
}
