using System.Threading.Tasks;

namespace NamiMetal.Data;

public interface INamiMetalDbSchemaMigrator
{
    Task MigrateAsync();
}
