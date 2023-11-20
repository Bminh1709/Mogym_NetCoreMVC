using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Infracstructure.Repositories;

namespace MOGYM.Areas.Trainee.Controllers
{
    [Area("Trainee")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;

        public HomeController(IUnitOfWork unitOfWork, IServiceRepository serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<IActionResult> Index(string filter)
        {
            ViewBag.TraineeNav = "Service";

            try
            {
                ViewBag.Filter = filter;
                var services = await _serviceRepository.GetServices(filter);
                return View(services);
            }
            catch (Exception ex)
            {
                return RedirectToAction("HandleError", "Home", new { message = ex.Message });
            }
        }
    }
}
