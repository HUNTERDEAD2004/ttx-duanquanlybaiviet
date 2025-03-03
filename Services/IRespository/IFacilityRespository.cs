using Services.DTO.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IFacilityRespository
    {
        Task<List<FacilityDTO>> GetAllFacilities();
        Task<FacilityDTO> GetFacilityById(int id);
        Task<bool> CreateFacility(FacilityDTO facilityDTO);
        Task<bool> UpdateFacility(FacilityDTO facilityDTO);
        Task<bool> DeleteFacility(int id);
    }
}
