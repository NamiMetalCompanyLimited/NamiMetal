using NamiMetal.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NamiMetal;

[DependsOn(
    typeof(NamiMetalEntityFrameworkCoreTestModule)
    )]
public class NamiMetalDomainTestModule : AbpModule
{

}
