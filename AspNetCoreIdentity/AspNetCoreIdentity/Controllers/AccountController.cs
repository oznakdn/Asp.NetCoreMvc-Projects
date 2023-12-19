using AspNetCoreIdentity.Models.Identity;
using AspNetCoreIdentity.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using AspNetCoreIdentity.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreIdentity.Models.Enums;

namespace AspNetCoreIdentity.Controllers
{

    public class AccountController : BaseController
    {

       

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager) { }
       


        #region Register

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile? userPicture)
        {

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            

            if (ModelState.IsValid)
            {

                AppUser appUser = new()
                {
                    Email = model.Email,
                    UserName = model.Username,
                    PhoneNumber = model.PhoneNumber,
                    City = model.City,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    Picture = model.Picture
                };

                // Resmi kaydetmek icin
                if (userPicture != null && userPicture.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(userPicture.FileName)}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture", fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    await userPicture.CopyToAsync(stream);
                    //user.Picture = "/Picture/" + userPicture.FileName;
                    appUser.Picture = fileName;

                }

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Registration is successful.";
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }


        #endregion

        #region Login
        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Veri tabaninda kullanici varliginin sorgulanmasi
                AppUser user = await _userManager.FindByEmailAsync(model.Email);

                // Veri tabaninda kullanici mevcut ise
                if (user != null)
                {
                    // Kullanicinin kilitli olup olmadigi sorgulanir. Eger kilitli ise
                    if(await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Your account has been blocked for a while!");
                        //return View(user);

                    }

                    // Daha once login olmussa logout yapar
                    await _signInManager.SignOutAsync();

                    // Giris yapar
                    SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    // Giris basarili ise
                    if (result.Succeeded)
                    {
                        // Giris basarili ise basarisiz giris sayisi sifirlanir
                        await _userManager.ResetAccessFailedCountAsync(user);

                        if (TempData["ReturnUrl"]!=null)
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    // Giris basarisiz ise
                    else
                    {
                        // Basarisiz giris sayisi arttirilir

                        int failLogin = await _userManager.GetAccessFailedCountAsync(user);
                        await _userManager.AccessFailedAsync(user);

                        ModelState.AddModelError("", $"{failLogin} times wrong writing!");


                        if (failLogin==3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddMinutes(15));
                            ModelState.AddModelError("", "Your account have been blocked 15 minutes for you wrote wrong three times your password! Please try again later.");
                        }

                        TempData["Message"] = "Email or Password is wrong!";
                        ModelState.AddModelError("", "Invalid email or password!");
                        return View(model);
                    }
                }
            }

            // Veri tabaninda kullanici mevcut degil ise
            TempData["Message"] = "User is not exists!";
            return View(model);
        }

        #endregion

        #region Password Reset

        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetViewModel model)
        {
            AppUser user =await _userManager.FindByEmailAsync(model.Email);

            if(user==null)
            {
                ModelState.AddModelError(nameof(model.Email), "Email is wrong!");
                return View(model);
            }

            string passwordResetToken =await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action("ResetPasswordConfirm","Account", 
            new
            {
                userId= user.Id,
                token = passwordResetToken,

            },HttpContext.Request.Scheme);

            PasswordResetMail.PasswordResetSendMail(link);
            TempData["Message"] = "Password reset message have been sended your mail.";
            return View();
        }

        
        public IActionResult PasswordResetConfirm(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordResetConfirm(PasswordResetConfirmViewModel model)
        {
            string id = TempData["userId"].ToString();
            string token = TempData["token"].ToString();

            AppUser user = await _userManager.FindByIdAsync(id);

            if(user!=null)
            {
                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                if(result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    TempData["Message"] = "Your password has been renewed, you can login your new password.";
                    return Redirect(nameof(Login));

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }

            TempData["Message"] = "There is an error, please try again later!";
            return View(model);
        }

        #endregion


    }
}
