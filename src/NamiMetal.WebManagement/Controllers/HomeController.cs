using Microsoft.AspNetCore.Mvc;

namespace NamiMetal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/ProductCategory");
        }
    }
}
