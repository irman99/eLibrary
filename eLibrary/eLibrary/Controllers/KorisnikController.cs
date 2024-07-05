using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    public class KorisnikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
