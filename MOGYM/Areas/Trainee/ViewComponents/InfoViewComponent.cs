using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.ViewComponents
{
    public class InfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
