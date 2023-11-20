using AutoMapper;
using MOGYM.Enums;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Helpers
{
    public class RoleUtility
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleUtility(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AssignRole(RoleEnum role, UserModel user)
        {
            switch (role)
            {
                case RoleEnum.Trainer:
                    await AssignRole<TrainerModel>(user, _unitOfWork.TrainerRepository);
                    break;
                case RoleEnum.Trainee:
                    await AssignRole<TraineeModel>(user, _unitOfWork.TraineeRepository);
                    break;
                default:
                    break;
            }
        }

        public async Task AssignRole<T>(UserModel user, IGenericRepository<T> roleRepository) where T : UserModel
        {
            T roleFound = await roleRepository.Get(user.Id);

            if (roleFound == null)
            {
                await _unitOfWork.UserRepository.Delete(user);

                T newRole = _mapper.Map<T>(user);

                newRole.Id = 0;

                await roleRepository.Create(newRole);
            }
        }
    }
}
