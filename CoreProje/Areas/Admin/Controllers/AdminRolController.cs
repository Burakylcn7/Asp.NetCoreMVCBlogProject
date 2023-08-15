using CoreProje.Areas.Admin.Models;
using CoreProje.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Values = _roleManager.Roles.ToList();
            return View(Values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel p)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = p.name
                };
                var result = await _roleManager.CreateAsync(role);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminRol");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id) 
        {
            var Values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateModel getModel = new RoleUpdateModel();
            getModel.Id = Values.Id;
            getModel.name = Values.Name;
            return View(getModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateModel p)
        {
            var Values = _roleManager.Roles.Where(x => x.Id == p.Id).FirstOrDefault();
            Values.Name = p.name;
            var result = await _roleManager.UpdateAsync(Values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index" , "AdminRol");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteUpdate(int id) 
        {
            var Values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result =await _roleManager.DeleteAsync(Values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRol");
            }
            return View();
        }

        public IActionResult UserRoleList() 
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["userId"] = user.Id;

            var userRoles =await _userManager.GetRolesAsync(user);

            List<RoleAssignModel> roleModel = new List<RoleAssignModel>();
            foreach (var role in roles) 
            { 
                RoleAssignModel model = new RoleAssignModel();
                model.RoleId = role.Id;
                model.Name = role.Name;
                model.Exists = userRoles.Contains(role.Name);
                roleModel.Add(model);
            }
            return View(roleModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel> roleAssignModels) 
        {
            var userid =(int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var role in roleAssignModels) 
            {
                if (role.Exists)
                {
                    await _userManager.AddToRoleAsync(user,role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,role.Name);
                }
            }
            return RedirectToAction("UserRoleList","AdminRol");
        }
    }
}
