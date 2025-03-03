using Common.Response;
using Services.DTO.Articles;
using Services.DTO.Articles_Hashtag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IArticles_HashtagRespository
    {
        Task<List<Articles_HashtagDTO>> GetAllArticles_Hashtag();

        Task<Articles_HashtagDTO> GetInfoArticles_HashtagById(int id);

        Task<ResponseDTO<Articles_HashtagDTO>> CreateArticles_Hashtag(CreateArticles_HashtagRespository request);

        Task<ResponseDTO<Articles_HashtagDTO>> UpdateArticles_Hashtag(UpdateArticles_HashtagRespository request);

        Task<ResponseDTO<bool>> DeleteArticles_Hashtag(int id);
    }
}
