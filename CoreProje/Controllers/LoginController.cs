using CoreProje.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginModel p)
        {
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                { 
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}


//[HttpPost]
//public async Task<IActionResult> Index(Writer p)
//{
//	CoreBlogDbContext coreBlogDbContext = new CoreBlogDbContext();
//	var datavalue = coreBlogDbContext.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//	if (datavalue != null)
//	{
//		var claims = new List<Claim>
//		{
//			new Claim(ClaimTypes.Name,p.WriterMail)
//		};
//		var useridentity = new ClaimsIdentity(claims,"a");
//		ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(useridentity);
//		await HttpContext.SignInAsync(claimsPrincipal);
//		return RedirectToAction("Index","Blog");
//	}
//	else
//	{
//		return View();
//	}
//}





//private readonly SignInManager<ApplicationUser> signInManager;
//private readonly UserManager<ApplicationUser> userManager;

//public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
//{
//    this.signInManager = signInManager;
//    this.userManager = userManager;
//}

//var user = await userManager.FindByEmailAsync(model.Email);
//var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);