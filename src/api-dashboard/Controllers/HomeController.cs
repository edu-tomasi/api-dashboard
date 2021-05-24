using Microsoft.AspNetCore.Mvc;

namespace WAProjetct.API.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
