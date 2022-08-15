//using Dapper;
//using Dapper.Contrib.Extensions;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Volo.Abp.DependencyInjection;
//using Volo.Abp.Domain.Repositories.Dapper;
//using Volo.Abp.EntityFrameworkCore;
//using Volo.Abp.EntityFrameworkCore.Modeling;

//namespace NamiMetal.EntityFrameworkCore
//{
//    public class ModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
//    {
//        public ModelBuilderConfigurationOptions(
//            [NotNull] string tablePrefix,
//            [CanBeNull] string schema = null)
//            : base(
//                tablePrefix,
//                schema)
//        {

//        }
//    }
//    public class BasicDapperRepositoryCore<T> : DapperRepository<NamiMetalDbContext>, ITransientDependency where T : class//, ICatalogDomainEntity
//    {
//        public BasicDapperRepositoryCore(IDbContextProvider<NamiMetalDbContext> dbContextProvider) : base(dbContextProvider)
//        {
//        }

//        public virtual async Task DeleteAsync(int id, bool autoSave = false, CancellationToken cancellationToken = default)
//        {
//            var options = new ModelBuilderConfigurationOptions(
//                NamiMetalConsts.DbTablePrefix,
//                NamiMetalConsts.DbSchema
//            );
//            var tableName = options.TablePrefix + nameof(T);
//            await DbConnection.ExecuteAsync($"delete from {tableName} where Id = {id}", DbTransaction);
//        }

//        public virtual async Task DeleteAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default) => await DbConnection.DeleteAsync(entity, DbTransaction);

//        public virtual async Task<T> FindAsync(int id, bool includeDetails = true, CancellationToken cancellationToken = default)
//        {
//            var options = new ModelBuilderConfigurationOptions(
//                DbProperties.DbTablePrefix,
//                DbProperties.DbSchema
//            );
//            var tableName = options.TablePrefix + nameof(T);
//            return (await DbConnection.QueryAsync<T>($"select * from {tableName} where Id = {id}", DbTransaction)
//                ).FirstOrDefault();
//        }

//        public virtual async Task<T> GetAsync(int id, bool includeDetails = true, CancellationToken cancellationToken = default)
//        {
//            var options = new ModelBuilderConfigurationOptions(
//                DbProperties.DbTablePrefix,
//                DbProperties.DbSchema
//            );
//            var tableName = options.TablePrefix + nameof(T);
//            return (await DbConnection.QueryAsync<T>($"select * from {tableName} where Id = {id}", DbTransaction)
//                ).FirstOrDefault();
//        }

//        public virtual async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
//        {
//            var options = new ModelBuilderConfigurationOptions(
//                DbProperties.DbTablePrefix,
//                DbProperties.DbSchema
//            );
//            var tableName = options.TablePrefix + nameof(T);
//            var result = await DbConnection.ExecuteScalarAsync<long>($"select count(1) from {tableName}", DbTransaction);
//            return result;
//        }

//        public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

//        public virtual async Task<List<T>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default) => (await DbConnection.GetAllAsync<T>()).ToList();
//        public virtual async Task<List<T>> GetListAsync2(bool includeDetails = false, CancellationToken cancellationToken = default) => (await DbConnection.GetAllAsync<T>(DbTransaction)).ToList();

//        public virtual async Task<T> InsertAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default)
//        {
//            await DbConnection.InsertAsync(entity, DbTransaction);
//            return entity;
//        }
//        public virtual async Task<T> CreateAsync(T entity) => await InsertAsync(entity);

//        public virtual async Task<List<T>> CreateAsync(List<T> entities)
//        {
//            //TODO Do Batch insert with dapper to optimize performance
//            foreach (var item in entities)
//            {
//                await InsertAsync(item);
//            }
//            return entities;
//        }

//        public async Task<T> UpdateAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default)
//        {
//            var result = await DbConnection.UpdateAsync(entity, DbTransaction);
//            if (result)
//                return entity;
//            else
//                return null;
//        }
//    }
//    public class BasicDapperRepository<T> : BasicDapperRepositoryCore<T> where T : class, ICatalogDomainEntity
//    {
//        public BasicDapperRepository(IDbContextProvider<DbContext> dbContextProvider) : base(dbContextProvider) { }
//        public async override Task<T> InsertAsync(T entity, bool autoSave = false, CancellationToken cancellationToken = default)
//        {
//            var id = await DbConnection.InsertAsync(entity, DbTransaction);
//            entity.SetId(id);
//            return entity;
//        }

//    }
//}
