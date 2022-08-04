using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NamiMetal.Data;
using Volo.Abp.DependencyInjection;

namespace NamiMetal.EntityFrameworkCore;

public class EntityFrameworkCoreNamiMetalDbSchemaMigrator
    : INamiMetalDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNamiMetalDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the NamiMetalDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NamiMetalDbContext>()
            .Database
            .MigrateAsync();
    }
}
