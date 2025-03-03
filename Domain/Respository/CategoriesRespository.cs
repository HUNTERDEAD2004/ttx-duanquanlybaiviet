using AppDomain.Object;
using Azure.Core;
using Common.Response;
using Domain.Data.Enum;
using Domain.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Articles;
using Services.DTO.Categories;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class CategoriesRespository : ICategoriesRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public CategoriesRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<ResponseDTO<CategoriesDTO>> CreateCategories(CreateCategoriesRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<CategoriesDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var createCategories = new Categories
                {
                   Name = request.Name,
                   Description = request.Description,
                   Royalty = request.Royalty,
                   Status = request.Status,
                };

                _appDbContext.Categories.Add(createCategories);
                _appDbContext.SaveChanges();

                return new ResponseDTO<CategoriesDTO>
                {
                    DataResponse = new CategoriesDTO
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Royalty = request.Royalty,
                        Status = request.Status,
                    },
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo chủ đề thành công."
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteCategories(int id)
        {
            var deleteCategories = await _appDbContext.Categories.FindAsync(id);
            if (deleteCategories != null)
            {
                _appDbContext.Categories.Remove(deleteCategories);
                _appDbContext.SaveChanges();
                return new ResponseDTO<bool>
                {
                    DataResponse = true,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công."
                };
            }
            return new ResponseDTO<bool>
            {
                DataResponse = false,
                Status = StatusCodes.Status400BadRequest,
                Message = "Xóa thất bại."
            };
        }

        public async Task<List<CategoriesDTO>> GetAllCategories()
        {
            var query = _appDbContext.Categories
                .Include(c => c.Articles)
                .Include(c => c.User_Registrations)
                .AsQueryable()
                .Where(c=> c.Status == EntityStatus.Active);

            var Categories = await query.Select(c => new CategoriesDTO
            {
                CategoryID = c.CategoryID,
                Name = c.Name,
                Description= c.Description,
                Royalty = c.Royalty,
            }).ToListAsync();

            return Categories;
        }

        public async Task<CategoriesDTO> GetInfoCategoriesById(int id)
        {
            var query = await _appDbContext.Categories
                .Include(c => c.Articles)
                .Include(c => c.User_Registrations)
                .Where(c => c.Status == EntityStatus.Active)
                .FirstOrDefaultAsync(a => a.CategoryID == id);
            if (query == null)
            {
                return null;
            }

            return new CategoriesDTO
            {
                Name = query.Name,
                Description = query.Description,
                Royalty = query.Royalty,
                Status = EntityStatus.Active,
            };
        }

        public async Task<ResponseDTO<CategoriesDTO>> UpdateCategories(UpdateCategoriesRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<CategoriesDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var categories = await _appDbContext.Categories
                .Include(c => c.Articles)
                .Include(c => c.User_Registrations)
                .FirstOrDefaultAsync(a => a.CategoryID == request.CategoryID);

                if (categories == null)
                {
                    return new ResponseDTO<CategoriesDTO>
                    {
                        DataResponse = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy bài viết."
                    };
                }

                categories.Name = request.Name;
                categories.Description = request.Description;
                categories.Royalty = request.Royalty;
                categories.Status = request.Status;

                _appDbContext.Categories.Update(categories);

                await _appDbContext.SaveChangesAsync();

                return new ResponseDTO<CategoriesDTO>
                {
                    DataResponse = new CategoriesDTO
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Royalty = request.Royalty,
                        Status = request.Status,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật chủ đề thành công."
                };
            }
        }
    }
}
