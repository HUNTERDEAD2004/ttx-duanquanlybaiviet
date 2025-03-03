using Services.DTO.WritingPhases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IWritingPhasesRespository
    {
        Task<List<WritingPhasesDTO>> GetAllWP();
        Task<WritingPhasesDTO> GetWPById(int id);
        Task<bool> CreateWP(WritingPhasesDTO wpdto);
        Task<bool> UpdateWP(WritingPhasesDTO wpdto);
        Task<bool> DeleteWP(int id);
    }
}
