using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        ICommentService _commentService = new CommentManager(new EFCommentDal());
        public IActionResult Index()
        {
            var Values = _commentService.GetCommentWithBlog();
            return View(Values);
        }
    }
}
