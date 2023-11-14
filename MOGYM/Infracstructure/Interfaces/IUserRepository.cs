﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsers(string filter);
        Task<bool> IsExist(string gmail);
        Task<UserModel> GetUser(string gmail);
    }
}
