using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreProje.ViewComponents.Writers
{
    public class WriterMessageNotification : ViewComponent
    {
        IMessageService _messageService = new MessageManager(new EFMessageDal());
        CoreBlogDbContext _context = new CoreBlogDbContext();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var Values = _messageService.GetInboxListByWriter(userid).TakeLast(3);
            return View(Values);
        }
    }
}
