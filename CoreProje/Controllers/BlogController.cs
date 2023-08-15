using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreProje.Controllers
{
    
    public class BlogController : Controller
    {
        IBlogService _blogService = new BlogManager(new EFBlogDal());
        BlogValidator _blogValidator = new BlogValidator();
        ICategoryService _categoryService = new CategoryManager(new EFCategoryDal());
        IWriterService _writerService = new WriterManager(new EFWriterDal());

        [AllowAnonymous]
        public IActionResult Index()
        {
            var Values = _blogService.GetBlogListWithCategory();
            return View(Values);
        }

        public IActionResult BlogReadAll(int id)
        { 
            ViewBag.i=id;
            var Values = _blogService.GetBlogByID(id);
            return View(Values); 
        }

        public IActionResult BlogListByWriter()
        {
            var loginUser = _writerService.GetByMail(User.Identity.Name).Select(x => x.WriterID).FirstOrDefault();
            var Values = _blogService.GetBlogListByWriter(loginUser);
            return View(Values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll() select new SelectListItem { Text = x.CategoryName, 
                                                                                                                  Value = x.CategoryID.ToString() }).ToList();
            ViewBag.categoryvalue = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var loginUser = _writerService.GetByMail(User.Identity.Name).Select(x => x.WriterID).FirstOrDefault();
            
            ValidationResult validationResult = _blogValidator.Validate(p);
            if (validationResult.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = loginUser;
                _blogService.BlogAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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

        public IActionResult BlogDelete(int id)
        {
            var Values = _blogService.GetByID(id);
            _blogService.BlogDelete(Values);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id) 
        {
            var Values = _blogService.GetByID(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll() select new SelectListItem { Text= x.CategoryName, 
                                                                                                                  Value= x.CategoryID.ToString() }).ToList();
            ViewBag.categoryvalues = categoryValues;
            return View(Values); 
        }

        [HttpPost]
        public IActionResult BlogUpdate(Blog p)
        {
            //ValidationResult validationResult = _blogValidator.Validate(p);
            //if (validationResult.IsValid)
            //{
                var blogValues = _blogService.GetByID(p.BlogID);
                p.WriterID = blogValues.WriterID;
                p.BlogCreateDate = blogValues.BlogCreateDate;
                p.BlogStatus = blogValues.BlogStatus;
                _blogService.BlogUpdate(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            //}
            //else
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
            //    }
            //}
            //return View();
        }
    }
}
