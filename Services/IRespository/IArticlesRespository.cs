using Common.Response;
using Services.DTO.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface IArticlesRespository
    {
        Task<List<ArticlesDTO>> GetAllArticles();

        Task<ArticlesDTO> GetInfoArticlesById(int id);

        Task<ResponseDTO<ArticlesDTO>> CreateArticles(CreateArticlesRequest request);

        Task<ResponseDTO<ArticlesDTO>> UpdateArticles(UpdateArticlesRequest request);

        Task<ResponseDTO<bool>> DeleteArticles(int id);
    }
}
