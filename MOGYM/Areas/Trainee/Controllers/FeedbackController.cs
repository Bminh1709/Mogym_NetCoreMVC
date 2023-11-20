using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.Controllers
{
    [Area("Trainee")]
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TraineeNav = "Feedback";
            return View();
        }
    }
}
