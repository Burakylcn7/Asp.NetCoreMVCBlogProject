using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProje.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService = new CategoryManager(new EFCategoryDal());
        public IActionResult Index()
        {
            var Values = _categoryService.GetAll();
            return View(Values);
        }

        [HttpGet]
        public IActionResult CategoryPageEdit(int id)
        {
            var Values = _categoryService.GetByID(id);
            return View(Values);
        }

        [HttpPost]
        public IActionResult CategoryPageEdit(Category p)
        {
            _categoryService.CategoryUpdate(p);
            return RedirectToAction("Index", "Category");
        }
    }
}
