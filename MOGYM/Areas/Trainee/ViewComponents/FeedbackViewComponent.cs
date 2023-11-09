using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.ViewComponents
{
    public class FeedbackViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
