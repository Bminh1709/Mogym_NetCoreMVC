﻿using MOGYM.Models;

namespace MOGYM.Infracstructure.Interfaces
{
    public interface ITraineeRepository
    {
        Task<TraineeModel> GetTrainee(int id);
    }
}
