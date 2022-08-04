using NamiMetal.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NamiMetal.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NamiMetalController : AbpControllerBase
{
    protected NamiMetalController()
    {
        LocalizationResource = typeof(NamiMetalResource);
    }
}
