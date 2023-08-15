using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Writers
{
    public class WriterNavbarProfile : ViewComponent
    {
        IWriterService _writerService = new WriterManager(new EFWriterDal());
        CoreBlogDbContext _context = new CoreBlogDbContext();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail);

            ViewBag.username = username;
            return View(userid);
        }
    }
}
