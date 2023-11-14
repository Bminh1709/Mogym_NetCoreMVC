using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MOGYM.Helpers;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Infracstructure.Services;
using MOGYM.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using System.Collections;

namespace MOGYM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<UserModel> _genericRepository;
        private readonly IUserRepository _userRepository;
        private readonly FileUploadService _fileUploadService;
        public HomeController(IGenericRepository<UserModel> genericRepository, IUserRepository userRepository, FileUploadService fileUploadService)
        {
            _genericRepository = genericRepository;
            _userRepository = userRepository;
            _fileUploadService = fileUploadService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            ClaimsPrincipal userClaim = HttpContext.User;
            if (userClaim.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult SignUp()
        {
            ClaimsPrincipal userClaim = HttpContext.User;
            if (userClaim.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(string gmail, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(gmail) || string.IsNullOrEmpty(password))
                {
                    ViewBag.ErrorMessage = "Bạn chưa điền đủ thông tin";
                    return View();
                }
                else if (!await _userRepository.IsExist(gmail))
                {
                    ViewBag.ErrorMessage = "Tài khoản Gmail không tồn tại";
                    return View();
                }

                UserModel userFound = await _userRepository.GetUser(gmail);
                string decryptedPassword = DataUtility.DecryptPassword(userFound.Password);

                if (password != decryptedPassword)
                {
                    ViewBag.ErrorMessage = "Sai mật khẩu";
                    return View();
                }

                // Setting Claims
                var claims = new List<Claim>
                {
                    // Claims are pieces of information about the user
                    new Claim(ClaimTypes.Name, userFound.Name),
                    new Claim("Avatar", userFound.Avatar),
                    new Claim(ClaimTypes.Email, userFound.Gmail),
                    new Claim(ClaimTypes.MobilePhone, userFound.PhoneNumber),
                    new Claim(ClaimTypes.NameIdentifier, userFound.Id.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Behavior of the authentication process
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // The authentication cookie will be stored on the user's machine even after closing the browser
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Xảy ra lỗi, vui lòng thử lại";
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(UserModel model, IFormFile avatar)
        {
            try
            {
                ModelState.Remove("Avatar"); // Avatar attribute can be null

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else if (await _userRepository.IsExist(model.Gmail))
                {
                    ModelState.AddModelError("Gmail", "Tài khoản này đã được sử dụng");
                    return View(model);
                }
                else if (avatar != null)
                {
                    model.Avatar = await _fileUploadService.UploadFile(avatar);
                }    

                model.Password = DataUtility.EncryptPassword(model.Password);
                await _genericRepository.Create(model); 

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }

            return RedirectToAction("SignIn");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}