using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService = new CommentManager(new EFCommentDal());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment() 
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogScore = 8;
            _commentService.CommentAdd(p);
            Response.Redirect("/Blog/BlogReadAll/" + p.BlogID);
            return PartialView();
        }
    }
}
