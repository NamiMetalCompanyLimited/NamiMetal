using Volo.Abp.Modularity;

namespace NamiMetal;

[DependsOn(
    typeof(NamiMetalApplicationModule),
    typeof(NamiMetalDomainTestModule)
    )]
public class NamiMetalApplicationTestModule : AbpModule
{

}
