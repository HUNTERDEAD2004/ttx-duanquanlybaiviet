using AppDomain.Object;
using Services.DTO.RegistrationPeriods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IRegistrationPeriodsRespository
    {
        Task<List<RegistrationPeriodsDTO>> GetAllRegistrations();
        Task<RegistrationPeriodsDTO> GetRegistrationsById(int id);
        Task<bool> CreateRegistrationPe(RegistrationPeriodsDTO registrationPeriodsDTO);
        Task<bool> UpdateRegistrationPe(RegistrationPeriodsDTO registrationPeriodsDTO);
        Task<bool> DeleteRegistrationPe(int id);
    }
}
