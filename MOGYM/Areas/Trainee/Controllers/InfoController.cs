using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;
using System.Security.Claims;

namespace MOGYM.Areas.Trainee.Controllers
{
    [Area("Trainee")]
    [Authorize(Roles = "Trainee")]
    public class InfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var trainee = await GetCurrentTraineeAsync();
                return View(trainee);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetHealthIndicator(int height, int weight)
        {
            try
            {
                var trainee = await GetCurrentTraineeAsync();

                trainee.Height = height;
                trainee.Weight = weight;

                await _unitOfWork.TraineeRepository.Update(trainee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        private async Task<TraineeModel?> GetCurrentTraineeAsync()
        {
            try
            {
                var traineeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (traineeId == null)
                    return null;

                var trainee = await _unitOfWork.TraineeRepository.Get(int.Parse(traineeId));

                return trainee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IActionResult HandleError(Exception ex)
        {
            return RedirectToAction("HandleError", "Home", new { message = ex.Message });
        }
    }
}
