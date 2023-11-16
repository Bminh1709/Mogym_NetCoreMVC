using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using MOGYM.Enums;
using MOGYM.Helpers;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Infracstructure.Repositories;
using MOGYM.Models;
using System.Data;
using System.Security.Claims;

namespace MOGYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }
   
        public async Task<IActionResult> Index(string filter)
        {
            ViewBag.Filter = filter;
            ViewData["Branches"] = await _unitOfWork.BranchRepository.GetAll();
            var users = await _userRepository.GetUsers(filter);
            return View(users);
        }
        public async Task<IActionResult> GetRole(int userId)
        {
            var user = await _userRepository.GetUserBranch(userId);
            int branchId = user.Branch?.Id ?? 0;
            int roleId = 0;
            if (user is TrainerModel) roleId = (int)RoleEnum.Trainer;
            else if (user is TraineeModel) roleId = (int)RoleEnum.Trainee;
            return Json(new { success = true, branchId = branchId, roleId = roleId });
        } 

        [HttpPost]
        public async Task<IActionResult> SetRole(int userId, int branchId, int roleId)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.Get(userId);
                var branch = await _unitOfWork.BranchRepository.Get(branchId);

                if (branch != null && user.Branch?.Id != branchId)
                {
                    user.Branch = branch;
                    await _unitOfWork.UserRepository.Update(user);
                }

                var roleUtility = new RoleUtility(_unitOfWork, _mapper);
                await roleUtility.AssignRole((RoleEnum)roleId, user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
                // return RedirectToAction("HandleError", "Home", new { message = ex.Message });
            }
        }
    }

}
