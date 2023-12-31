﻿using Microsoft.EntityFrameworkCore;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext,
        IGenericRepository<UserModel> userRepository,
        IGenericRepository<BranchModel> branchRepository,
        IGenericRepository<TrainerModel> trainerRepository,
        IGenericRepository<TraineeModel> traineeRepository,
        IGenericRepository<AdminModel> adminRepository,
        IGenericRepository<ServiceModel> serviceRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            BranchRepository = branchRepository;
            TrainerRepository = trainerRepository;
            TraineeRepository = traineeRepository;
            AdminRepository = adminRepository;
            ServiceRepository = serviceRepository;
        }

        public IGenericRepository<UserModel> UserRepository { get; }
        public IGenericRepository<BranchModel> BranchRepository { get; }
        public IGenericRepository<TrainerModel> TrainerRepository { get; }
        public IGenericRepository<TraineeModel> TraineeRepository { get; }
        public IGenericRepository<AdminModel> AdminRepository { get; }
        public IGenericRepository<ServiceModel> ServiceRepository { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
