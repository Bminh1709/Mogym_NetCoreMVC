using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.Controllers
{
    [Area("Trainee")]
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TraineeNav = "Message";
            return View();
        }
    }
}
