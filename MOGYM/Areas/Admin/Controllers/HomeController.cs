using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using MOGYM.Enums;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Infracstructure.Repositories;
using MOGYM.Infracstructure.Services;
using MOGYM.Models;
using System.Security.Claims;

namespace MOGYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly FileUploadService _fileUploadService;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomeController(FileUploadService fileUploadService, IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
        {
            _fileUploadService = fileUploadService;
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string filter)
        {
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

        [HttpPost]
        public async Task<IActionResult> UpSertService(ServiceModel model, IFormFile image)
        {
            try
            {
                if (model.Id == 0)
                {
                    await AddService(model, image);
                }
                else {

                    await UpdateService(model, image);
                }
               
            }
            catch (Exception ex)
            {
                return RedirectToAction("HandleError", "Home", new { message = ex.Message });
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetService(int serviceId)
        {
            try
            {
                var service = await _unitOfWork.ServiceRepository.Get(serviceId);
                return Json(new { success = true, data = service });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            try
            {
                var service = await _unitOfWork.ServiceRepository.Get(serviceId);

                if (service == null)
                    return RedirectToAction("HandleError", "Home", new { code = 500 });

                if (service.Image != null)
                    _fileUploadService.DeleteFile(service.Image, "Service");

                await _unitOfWork.ServiceRepository.Delete(service);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("HandleError", "Home", new { message = ex.Message });
            }
        }

        private async Task UpdateService(ServiceModel model, IFormFile image)
        {
            var service = await _unitOfWork.ServiceRepository.Get(model.Id);

            if (image != null && service.Image != null)
                _fileUploadService.DeleteFile(service.Image, "Service");

            if (image != null)
                model.Image = await _fileUploadService.UploadFile(image, "Service");
            else
                model.Image = service.Image;

            _mapper.Map(model, service);

            await _unitOfWork.SaveChanges();
        }

        private async Task AddService(ServiceModel model, IFormFile image)
        {
            var branchId = User.FindFirstValue(ClaimTypes.Locality);

            if (branchId != null)
            {
                model.Branch = await _unitOfWork.BranchRepository.Get(int.Parse(branchId));
            }

            if (image != null)
            {
                model.Image = await _fileUploadService.UploadFile(image, "Service");
            }

            await _unitOfWork.ServiceRepository.Create(model);
        }

        
    }
}
