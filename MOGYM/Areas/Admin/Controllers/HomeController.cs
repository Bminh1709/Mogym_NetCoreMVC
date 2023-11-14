using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;
using System.Security.Claims;

namespace MOGYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<UserModel> _genericRepository;
        public HomeController(IGenericRepository<UserModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Index");
            }
        }
    }
}
