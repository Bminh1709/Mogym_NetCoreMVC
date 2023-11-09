using Microsoft.AspNetCore.Mvc;
using MOGYM.Infracstructure.Repositories;
using MOGYM.Models;
using System.Diagnostics;

namespace MOGYM.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseRepository<User, int> _userRepository;
        public HomeController(BaseRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(model);
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}