using Volo.Abp.Domain.Entities;

namespace NamiMetal.Domain
{
    public interface IDomainEntity<T_Key> : IEntity<T_Key>
    {
        void SetId(T_Key id);
    }
    public interface IChildrenDomainEntity<T_Key> : IDomainEntity<T_Key>
    {
        void SetParentRelationship(T_Key id);
    }
}
