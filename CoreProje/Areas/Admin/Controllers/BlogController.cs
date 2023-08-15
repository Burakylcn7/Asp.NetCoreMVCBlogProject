using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        IBlogService _blogService = new BlogManager(new EFBlogDal());
        public IActionResult Index()
        {
            var Values = _blogService.GetBlogListWithCategory();
            return View(Values);
        }
    }
}
