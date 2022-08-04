using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace NamiMetal.Web;

[Dependency(ReplaceServices = true)]
public class NamiMetalBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NamiMetal";
}
