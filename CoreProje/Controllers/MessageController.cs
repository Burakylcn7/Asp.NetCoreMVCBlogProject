using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;

namespace CoreProje.Controllers
{
    public class MessageController : Controller
    {
        IMessageService _messageService = new MessageManager(new EFMessageDal());
        CoreBlogDbContext _context = new CoreBlogDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InBox() 
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var Values = _messageService.GetInboxListByWriter(userid);
            return View(Values);
        }

        public IActionResult SendBox() 
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var Values = _messageService.GetSendboxListByWriter(userid);
            return View(Values);
        }

        public IActionResult MessageDetails(int id) 
        {
            var Values = _messageService.GetByID(id);
            return View(Values);
        }

        [HttpGet]
        public IActionResult SendMessage() 
        {
            List<SelectListItem> ReceiverMessageValues = (from x in _context.Users select new SelectListItem() { Text = x.NameSurname, Value = x.Id.ToString() }).ToList();
            ViewBag.ReceiverValues = ReceiverMessageValues;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userid = _context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = userid;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            _messageService.MessageAdd(p);
            return RedirectToAction("InBox","Message");
        }
    }
}
