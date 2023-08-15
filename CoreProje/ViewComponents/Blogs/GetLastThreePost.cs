using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Blogs
{
	public class GetLastThreePost : ViewComponent
	{
		IBlogService _blogService = new BlogManager(new EFBlogDal());

		public IViewComponentResult Invoke()
		{
			var Values = _blogService.GetLastThreePost(); 
			return View(Values);
		}
	}
}
