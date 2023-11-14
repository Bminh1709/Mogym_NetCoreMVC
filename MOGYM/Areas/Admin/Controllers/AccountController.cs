using Microsoft.AspNetCore.Mvc;
using MOGYM.Enums;
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
        private readonly IBranchRepository _branchRepository;
        
        public AccountController(IUnitOfWork unitOfWork, IUserRepository userRepository,  IBranchRepository branchRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _branchRepository = branchRepository;
        }
   
        public async Task<IActionResult> Index(string filter)
        {
            ViewBag.Filter = filter;
            ViewData["Branches"] = await _branchRepository.GetBranches();
            var users = await _userRepository.GetUsers(filter);
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(int userId, int branchId, int roleId)
        {
            var user = await _unitOfWork.UserRepository.Get(userId);
            var branch = await _unitOfWork.BranchRepository.Get(branchId);

            if (user != null && branch != null)
            {
                user.Branch = branch;

                await _unitOfWork.UserRepository.Update(user);

                await HandleRoleSpecificLogicAsync((RoleEnum)roleId, userId);

                return RedirectToAction("Index");
            }

            return View();
        }

        private async Task HandleRoleSpecificLogicAsync(RoleEnum role, int userId)
        {
            switch (role)
            {
                case RoleEnum.Trainer:
                    var trainerFound = await _unitOfWork.TrainerRepository.Get(userId);
                    if (trainerFound == null)
                    {
                        int adminId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                        AdminModel adminFound = await _unitOfWork.AdminRepository.Get(adminId);
                        await _unitOfWork.TrainerRepository.Create(new TrainerModel { Id = userId, Admin = adminFound });
                    }
                    break;
                case RoleEnum.Trainee:
                    var traineeFound = await _unitOfWork.TraineeRepository.Get(userId);
                    if (traineeFound == null)
                    {
                        UserModel existingUser = await _unitOfWork.UserRepository.Get(userId);
                        TraineeModel newTrainee = new TraineeModel();

                        if (existingUser != null)
                        {

                            // Use reflection to copy properties from User to Trainee
                            foreach (var propertyInfo in typeof(UserModel).GetProperties())
                            {
                                // Exclude properties you don't want to copy, e.g., Id
                                if (propertyInfo.Name != "Id")
                                {
                                    var value = propertyInfo.GetValue(existingUser);
                                    propertyInfo.SetValue(newTrainee, value);
                                }
                            }
                        }
                        await _unitOfWork.TraineeRepository.Create(newTrainee);
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
