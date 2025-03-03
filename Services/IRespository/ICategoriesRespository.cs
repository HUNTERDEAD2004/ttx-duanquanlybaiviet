using Common.Response;
using Services.DTO.Articles;
using Services.DTO.Categories;
using Services.DTO.Hashtag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRespository
{
    public interface ICategoriesRespository
    {
        Task<List<CategoriesDTO>> GetAllCategories();

        Task<CategoriesDTO> GetInfoCategoriesById(int id);

        Task<ResponseDTO<CategoriesDTO>> CreateCategories(CreateCategoriesRequest request);

        Task<ResponseDTO<CategoriesDTO>> UpdateCategories(UpdateCategoriesRequest request);

        Task<ResponseDTO<bool>> DeleteCategories(int id);
    }
}
