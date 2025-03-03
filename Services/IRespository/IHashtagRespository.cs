using Common.Response;
using Services.DTO.Articles;
using Services.DTO.Articles_Hashtag;
using Services.DTO.Hashtag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IHashtagRespository
    {
        Task<List<HashtagDTO>> GetAllHashtag();

        Task<HashtagDTO> GetInfoHashtagById(int id);

        Task<ResponseDTO<HashtagDTO>> CreateHashtag(CreateHashtagRequest request);

        Task<ResponseDTO<HashtagDTO>> UpdateHashtag(UpdateHashtagRequest request);

        Task<ResponseDTO<bool>> DeleteHashtag(int id);
    }
}
