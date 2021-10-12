using Forum.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebAPI.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<List<UsersDto>> GetUsers();
        Task<UsersDto> GetByUsername(string username);
        Task<UsersDto> GetById(int id);
        Task<List<UsersDto>> SearchUsers(string searchTerm);

    }
}
