using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Categories
{
    public class CategoryList : ViewComponent
    {
        ICategoryService _categoryService = new CategoryManager(new EFCategoryDal());

        public IViewComponentResult Invoke() 
        {
            var Values = _categoryService.GetAll();
            return View(Values);
        }
    }
}
