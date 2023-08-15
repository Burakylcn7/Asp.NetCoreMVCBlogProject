using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAdminNavbar()
        {
            return PartialView();
        }
    }
}
