using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Comments
{
    public class CommentListByBlog : ViewComponent
    {
        ICommentService _commentService = new CommentManager(new EFCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var Values = _commentService.GetCommentByID(id);
            return View(Values);
        }
    }
}
