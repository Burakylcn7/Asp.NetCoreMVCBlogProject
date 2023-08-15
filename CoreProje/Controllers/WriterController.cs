using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProje.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService = new WriterManager(new EFWriterDal());
        CoreBlogDbContext _context = new CoreBlogDbContext();
        //WriterValidator _writerValidator = new WriterValidator();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult PartialWriterNavbar()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult PartialWriterFooter()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateModel getmodel = new UserUpdateModel();

            // model.username = values.UserName;
            getmodel.namesurname = values.NameSurname;
            getmodel.imageurl = values.ImageUrl;
            getmodel.phone = values.PhoneNumber;
            getmodel.mail = values.Email;
            return View(getmodel);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PhoneNumber = model.phone;
            if (model.password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            }
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}


//[HttpGet]
//public IActionResult WriterEditProfile()
//{
//    var loginUser = _writerService.GetByMail(User.Identity.Name).Select(x => x.WriterID).FirstOrDefault();
//    var Values = _writerService.GetByID(loginUser);
//    return View(Values);
//}

//[HttpPost]
//public IActionResult WriterEditProfile(Writer writer)
//{
//    ValidationResult validationResult = _writerValidator.Validate(writer);

//    if (validationResult.IsValid)
//    {
//        if (writer.WriterImageFile != null)
//        {
//            var extension = Path.GetExtension(writer.WriterImageFile.FileName); //GetExtension - son karakterden başlayıp ilk karakterine doğru devam ederek bir nokta (".") arayarak uzantısını alır.
//            var newImageName = Guid.NewGuid() + extension;
//            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
//            var stream = new FileStream(location, FileMode.Create);
//            writer.WriterImageFile.CopyTo(stream);
//            writer.WriterImage = Path.Combine("/WriterImageFiles/", newImageName);
//        }
//        else
//        {
//            var WriterValues = _writerService.GetByID(writer.WriterID);
//            writer.WriterImage = WriterValues.WriterImage;
//        }

//        writer.WriterStatus = true;
//        _writerService.WriterUpdate(writer);
//        return RedirectToAction("Index", "Dashboard");
//    }
//    else
//    {
//        foreach (var item in validationResult.Errors)
//        {
//            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//        }
//    }

//    return View();
//}