using Volo.Abp.Modularity;

namespace NamiMetal;

[DependsOn(
    typeof(NamiMetalDomainSharedModule)
)]
public class NamiMetalApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        NamiMetalDtoExtensions.Configure();
    }
}
