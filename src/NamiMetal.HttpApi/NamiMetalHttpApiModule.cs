using Localization.Resources.AbpUi;
using NamiMetal.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace NamiMetal;

[DependsOn(
    typeof(NamiMetalApplicationContractsModule)
    )]
public class NamiMetalHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NamiMetalResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
