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

        Task<bool> CreateArticles(CreateArticlesRequest request);

        Task<bool> UpdateArticles(UpdateArticlesRequest request);

        Task<bool> DeleteArticles(int id);
    }
}
