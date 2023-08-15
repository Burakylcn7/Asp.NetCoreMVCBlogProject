using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProje.Models;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        //IWriterService _writerService = new WriterManager(new EFWriterDal());
        //      WriterValidator _writerValidator = new WriterValidator();

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterModel p)
        {
            if (p.ImageFile != null)
            {
                var extension = Path.GetExtension(p.ImageFile.FileName); //GetExtension - son karakterden başlayıp ilk karakterine doğru devam ederek bir nokta (".") arayarak uzantısını alır.
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = Path.Combine("/WriterImageFiles/", newImageName);
            }
            else
            {
                p.ImageUrl = "/WriterImageFiles/defaultavatarphoto.jpg";
            }

            //if (ModelState.IsValid)
            //{
                AppUser user = new AppUser()
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname,
                    ImageUrl = p.ImageUrl
                };

                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            //}
            return View(p);
        }
    }


    //      [HttpPost]
    //public IActionResult Index(Writer w)
    //{
    //	ValidationResult validationResult= _writerValidator.Validate(w);
    //	if (validationResult.IsValid)
    //	{
    //		if (w.WriterImageFile != null)
    //		{
    //                  var extension = Path.GetExtension(w.WriterImageFile.FileName); //GetExtension - son karakterden başlayıp ilk karakterine doğru devam ederek bir nokta (".") arayarak uzantısını alır.
    //                  var newImageName = Guid.NewGuid() + extension;
    //                  var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
    //                  var stream = new FileStream(location, FileMode.Create);
    //                  w.WriterImageFile.CopyTo(stream);
    //			w.WriterImage = Path.Combine("/WriterImageFiles/", newImageName);
    //              }
    //		else
    //		{
    //			w.WriterImage = "/WriterImageFiles/defaultavatarphoto.jpg";
    //              }

    //              w.WriterStatus = true;
    //              _writerService.WriterAdd(w);
    //              return RedirectToAction("Index", "Blog");
    //          }
    //	else
    //	{
    //		foreach (var item in validationResult.Errors)
    //		{
    //			ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
    //		}
    //	}
    //	return View();

    //}
}

