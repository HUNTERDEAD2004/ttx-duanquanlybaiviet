using Common.Response;
using Services.DTO.Articles;
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

        Task<FacilityDTO> GetInfoFacilitiesById(int id);

        Task<ResponseDTO<FacilityDTO>> CreateFacilities(CreateFacilitiesRequest request);

        Task<ResponseDTO<FacilityDTO>> UpdateFacilities(UpdateFacilitiesRequest request);

        Task<ResponseDTO<bool>> DeleteFacilities(int id);
    }
}
