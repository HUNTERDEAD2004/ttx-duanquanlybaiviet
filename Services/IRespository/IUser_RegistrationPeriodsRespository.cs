using Services.DTO.User_RegistrationPeriods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IUser_RegistrationPeriodsRespository
    {
        Task<List<User_RegistrationPeriodsDTO>> GetAllURP();
        Task<User_RegistrationPeriodsDTO> GetURPById(int id);
        Task<bool> CreateURP(User_RegistrationPeriodsDTO urpdto);
        Task<bool> UpdateURP(User_RegistrationPeriodsDTO urpdto);
        Task<bool> DeleteURP(int id);

    }
}
