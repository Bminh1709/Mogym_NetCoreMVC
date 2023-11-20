using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TrainerNav = "Schedule";
            return View();
        }
    }
}
