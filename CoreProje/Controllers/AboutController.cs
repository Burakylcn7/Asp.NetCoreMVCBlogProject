using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
	public class AboutController : Controller
	{
		IAboutService _aboutService = new AboutManager(new EFAboutDal());
		public IActionResult Index()
		{
			var Values = _aboutService.GetAll();
			return View(Values);
		}

		public PartialViewResult PartialSocialMediaAbout()
		{
			return PartialView();
		}
	}
}
