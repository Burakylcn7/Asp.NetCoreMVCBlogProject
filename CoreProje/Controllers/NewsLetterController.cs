using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        INewsletterService _newsletterService = new NewsletterManager(new EFNewsletterDal());

        [HttpGet]
        public PartialViewResult PartialSubscribeMail()
        {
            return PartialView();
        }
       
        [HttpPost]
        public IActionResult PartialSubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            _newsletterService.NewsLetterAdd(p);
            //return View();
            return RedirectToAction("Index", "Blog");
        }
    }
}
