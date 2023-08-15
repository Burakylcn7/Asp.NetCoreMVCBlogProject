using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using X.PagedList;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService = new CategoryManager(new EFCategoryDal());
        CategoryValidator _categoryValidator = new CategoryValidator();
        public IActionResult Index(int page=1)
        {
            var Values = _categoryService.GetAll().ToPagedList(page, 3);
            return View(Values);
        }

        [HttpGet]
        public IActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            ValidationResult validationResult = _categoryValidator.Validate(p);
            if (validationResult.IsValid) 
            {
                p.CategoryStatus = false;
                _categoryService.CategoryAdd(p);
                return RedirectToAction("Index","Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryPassive(int id) 
        {
            var categoryValues = _categoryService.GetByID(id);
            categoryValues.CategoryStatus= false;
            _categoryService.CategoryUpdate(categoryValues);
            return RedirectToAction("Index", "Category");
        }

        public IActionResult CategoryActive(int id) 
        {
            var categoryValues = _categoryService.GetByID(id);
            categoryValues.CategoryStatus = true;
            _categoryService.CategoryUpdate(categoryValues);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        { 
            var Values = _categoryService.GetByID(id);
            return View(Values); 
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            ValidationResult validationResult = _categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                _categoryService.CategoryUpdate(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
