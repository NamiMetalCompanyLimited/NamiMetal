using NamiMetal.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace NamiMetal.Web.Pages;

public abstract class NamiMetalPageModel : AbpPageModel
{
    protected NamiMetalPageModel()
    {
        LocalizationResourceType = typeof(NamiMetalResource);
    }
}
