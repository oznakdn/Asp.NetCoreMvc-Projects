using AspNetCoreIdentity.Models.Identity;
using AspNetCoreIdentity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class AdminController : BaseController
    {

        private readonly RoleManager<AppRole> _roleManager;
        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager)
        {
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }


        #region List Users

        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        #endregion

        #region List Roles

        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();

            var result = roles.Select(x => new RoleViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name
            }).ToList();

            return View(result);
        }

        #endregion

        #region Create Role

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateViewModel model)
        {

            if (ModelState.IsValid)
            {

                var roles = _roleManager.Roles.Where(x => x.Name.ToLower() == model.Name.ToLower()).ToList();
                var roleModels = roles.Select(x => new RoleViewModel
                {
                    Name = x.Name
                }).ToList();


                if (roleModels.Any())
                {
                    ViewBag.Message = "Role is exists already!";
                    return View(model);
                }

                AppRole role = new()
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Role has been created successfully.";
                    return View();
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(model);
            }
            return View(model);
        }

        #endregion

        #region Delete Role

        public IActionResult DeleteRole(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            var result = _roleManager.DeleteAsync(role).Result;
            if (result.Succeeded)
            {
                ViewBag.Message = "Role was deleted successfully.";
                return RedirectToAction(nameof(Roles));
            }
            ViewBag.Message = "There is an error!";
            return View(nameof(Roles));
        }

        #endregion

        #region Update Role
        public IActionResult UpdateRole(string id)
        {
            AppRole role = _roleManager.FindByIdAsync(id).Result;
            TempData["id"] = id;

            RoleUpdateViewModel model = new()
            {
                Name = role.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateRole(RoleUpdateViewModel model)
        {
            AppRole role = _roleManager.FindByIdAsync(TempData["id"].ToString()).Result;

            if (ModelState.IsValid)
            {
                role.Name = model.Name;
                var result = _roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    ViewBag.Message = "Role was updated successfully.";
                    return View(model);
                }

                ViewBag.Message = "There is an error!";
                return View(model);
            }

            return View(model);
        }
        #endregion

        #region User Assign Role (rol atama)

        public IActionResult UserRoleAssign(string id)
        {
            AppUser user = _userManager.FindByIdAsync(id).Result;
            TempData["userId"] = id;
            ViewBag.userName = user.UserName;

            var roles = _roleManager.Roles.ToList();
           
            var userRoles = _userManager.GetRolesAsync(user).Result;

            List<RoleAssignViewModel> models = new();

            foreach (var role in roles)
            {
                RoleAssignViewModel model = new()
                {
                    RoleId = role.Id.ToString(),
                    Name = role.Name
                };
               
                if (userRoles.Contains(role.Name))
                {
                    
                    model.IsChacked = true;
                }
                else
                {
                    model.IsChacked = false;

                }

                models.Add(model);
            }

            return View(models);
        }


        [HttpPost]
        public IActionResult UserRoleAssign(List<RoleAssignViewModel> models)
        {
            AppUser user = _userManager.FindByIdAsync(TempData["userId"].ToString()).Result;

            foreach (var model in models)
            {
                if(model.IsChacked)
                {
                    _userManager.AddToRoleAsync(user, model.Name);
                }
                else
                {
                    _userManager.RemoveFromRoleAsync(user, model.Name);
                }
            }
            return RedirectToAction(nameof(Users));
        }


        #endregion


    }
}
