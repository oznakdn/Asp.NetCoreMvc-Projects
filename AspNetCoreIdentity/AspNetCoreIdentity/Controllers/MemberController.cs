using AspNetCoreIdentity.Models.Enums;
using AspNetCoreIdentity.Models.Identity;
using AspNetCoreIdentity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreIdentity.Controllers
{

    public class MemberController : BaseController
    {
       
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager):base(userManager,signInManager){}

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            UserViewModel model = new()
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                City = user.City,
                BirthDate = user.BirthDate.ToString(),
                Gender = user.Gender == 0 ? "Female" : "Male",
                Picture = user.Picture
            };
            return View(model);

        }


        #region Password Change
        public IActionResult PasswordChange()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                bool checkOldPassword = await _userManager.CheckPasswordAsync(user, model.OldPassword);

                if (checkOldPassword)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        // Degisiklik update edilir
                        await _userManager.UpdateSecurityStampAsync(user);

                        // Kullaniciya otomatik cikis yapilip tekrar giris yapilir
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, model.NewPassword, true, false);

                        TempData["Message"] = "Password is changed successfully.";
                        return View();
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        return View(model);
                    }
                }

                ModelState.AddModelError("", "Old password is wrong!");
                return View(model);
            }

            return View(model);
        }

        #endregion

        #region User Edit

        public async Task<IActionResult> UserEdit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            UserEditViewModel model = new()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                Picture = user.Picture
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel model, IFormFile? userPicture)
        {

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            if (ModelState.IsValid)
            {

                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                // Resmi kaydetmek icin
                if(userPicture!= null && userPicture.Length>0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(userPicture.FileName)}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture", fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    await userPicture.CopyToAsync(stream);
                    //user.Picture = "/Picture/" + userPicture.FileName;
                    user.Picture = fileName;

                }

                user.PhoneNumber = model.PhoneNumber;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.BirthDate = model.BirthDate;
                user.Gender =model.Gender;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Degisiklik update edilir
                    await _userManager.UpdateSecurityStampAsync(user);
                    // Kullaniciya otomatik cikis yapilip tekrar giris yapilir
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);

                    TempData["Message"] = "User informatin was changed successfully.";
                    return View();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

            }
            return View(model);
        }


        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Access Denied
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

    }
}
