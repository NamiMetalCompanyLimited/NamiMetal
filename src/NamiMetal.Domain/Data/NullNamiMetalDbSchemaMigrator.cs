using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NamiMetal.Data;

/* This is used if database provider does't define
 * INamiMetalDbSchemaMigrator implementation.
 */
public class NullNamiMetalDbSchemaMigrator : INamiMetalDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
