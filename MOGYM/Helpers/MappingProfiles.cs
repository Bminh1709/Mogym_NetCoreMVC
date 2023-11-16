using AutoMapper;
using MOGYM.Models;

namespace MOGYM.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserModel, TraineeModel>();
            CreateMap<UserModel, TrainerModel>();
        }
    }
}
