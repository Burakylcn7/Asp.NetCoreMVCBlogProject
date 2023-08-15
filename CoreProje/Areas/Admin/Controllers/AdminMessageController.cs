using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        IMessageService _messageService = new MessageManager(new EFMessageDal());
        CoreBlogDbContext _context = new CoreBlogDbContext();

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var Values = _messageService.GetInboxListByWriter(userid);
            ViewBag.InboxCount = Values.Count();
            return View(Values);
        }

        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var Values = _messageService.GetSendboxListByWriter(userid);
            ViewBag.SendboxCount = Values.Count();
            return View(Values);
        }

        [HttpGet]
        public IActionResult ComposeMessage() 
        {
            List<SelectListItem> ReceiverMessageValues = (from x in _context.Users select new SelectListItem() { Text = x.NameSurname, Value = x.Id.ToString() }).ToList();
            ViewBag.ReceiverValues = ReceiverMessageValues;
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message p)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = userid;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            _messageService.MessageAdd(p);
            return RedirectToAction("Inbox", "AdminMessage");
        }
    }
}
