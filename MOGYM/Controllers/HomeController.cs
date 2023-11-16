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
using System;

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

                var user = await _userRepository.GetUser(gmail);
                string decryptedPassword = DataUtility.DecryptPassword(user.Password);

                if (password != decryptedPassword)
                {
                    ViewBag.ErrorMessage = "Sai mật khẩu";
                    return View();
                }

                // Setting Claims
                var claims = new List<Claim>
                {
                    // Claims are pieces of information about the user
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Gmail),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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

        [Route("/Home/Error/{code:int}")]
        public IActionResult HandleError(int code, string message)
        {
            switch (code)
            {
                case 404:
                    ViewData["ErrorCode"] = "404";
                    ViewData["ErrorMessage"] = "Trang bạn đang tìm kiếm không khả dụng!";
                    break;
                case 403:
                    ViewData["ErrorCode"] = "403";
                    ViewData["ErrorMessage"] = "Bạn không có quyền truy cập tài nguyên được yêu cầu trên máy chủ!";
                    break;
                case 500:
                    ViewData["ErrorCode"] = "500";
                    ViewData["ErrorMessage"] = "Lỗi máy chủ!";
                    break;
                case 400:
                    ViewData["ErrorCode"] = "400";
                    ViewData["ErrorMessage"] = "Hiện máy chủ web không thể xử lý truy vấn!";
                    break;
                default:
                    ViewData["ErrorCode"] = "Error";
                    ViewData["ErrorMessage"] = message;
                    break;
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}