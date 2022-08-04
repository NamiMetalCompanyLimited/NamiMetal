using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace NamiMetal.Web.Pages;

public class IndexModel : NamiMetalPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
