using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
