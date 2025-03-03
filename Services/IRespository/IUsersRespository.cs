using Services.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IUsersRespository
    {
        Task<List<UsersDTO>> GetAllUsers();
        Task<UsersDTO> GetUserById(int id);
        Task<bool> CreateUser(UsersDTO userDTO);
        Task<bool> UpdateUser(UsersDTO userDTO);
        Task<bool> DeleteUser(int id);
    }
}
