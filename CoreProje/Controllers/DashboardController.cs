using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class DashboardController : Controller
    {
        CoreBlogDbContext _context = new CoreBlogDbContext();

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.TotalBlogCount = _context.Blogs.Count().ToString();

            var user = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == user).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.WriterBlogCount = _context.Blogs.Where(x => x.WriterID==userid).Count().ToString();

            ViewBag.TotalCategoryCount = _context.Categories.Count().ToString();
            return View();
        }
    }
}
