using NamiMetal.Localization;
using Volo.Abp.Application.Services;

namespace NamiMetal;

/* Inherit your application services from this class.
 */
public abstract class NamiMetalAppService : ApplicationService
{
    protected NamiMetalAppService()
    {
        LocalizationResource = typeof(NamiMetalResource);
    }
}
