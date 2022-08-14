using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace NamiMetal;

[DependsOn(
    typeof(NamiMetalDomainModule),
    typeof(NamiMetalApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class NamiMetalApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<NamiMetalApplicationModule>();
        });

        Configure<AbpExceptionHandlingOptions>(options =>
        {
            options.SendExceptionsDetailsToClients = true;
            options.SendStackTraceToClients = false;
        });
    }
}
