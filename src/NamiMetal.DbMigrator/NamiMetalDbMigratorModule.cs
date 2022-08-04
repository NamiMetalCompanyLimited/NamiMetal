using NamiMetal.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace NamiMetal.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NamiMetalEntityFrameworkCoreModule),
    typeof(NamiMetalApplicationContractsModule)
    )]
public class NamiMetalDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
