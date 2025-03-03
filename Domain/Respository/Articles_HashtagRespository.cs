using AppDomain.Object;
using Common.Response;
using Domain.Data.Enum;
using Domain.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Articles;
using Services.DTO.Articles_Hashtag;
using Services.DTO.Categories;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class Articles_HashtagRespository : IArticles_HashtagRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public Articles_HashtagRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<ResponseDTO<Articles_HashtagDTO>> CreateArticles_Hashtag(CreateArticles_HashtagRespository request)
        {
            if (request == null)
            {
                return new ResponseDTO<Articles_HashtagDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var createArticles_HashtagDTO = new Articles_Hashtag
                {
                    HashtagID = request.HashtagID,
                    ArcticleID = request.ArcticleID,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _appDbContext.Articles_Hashtags.Add(createArticles_HashtagDTO);
                _appDbContext.SaveChanges();

                return new ResponseDTO<Articles_HashtagDTO>
                {
                    DataResponse = new Articles_HashtagDTO
                    {
                        HashtagID = request.HashtagID,
                        ArcticleID = request.ArcticleID,
                        CreateDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                    },
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo hashtag bài viết thành công."
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteArticles_Hashtag(int id)
        {
            var deleteArticles_Hashtag = await _appDbContext.Articles_Hashtags.FindAsync(id);
            if (deleteArticles_Hashtag != null)
            {
                _appDbContext.Articles_Hashtags.Remove(deleteArticles_Hashtag);
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

        public async Task<List<Articles_HashtagDTO>> GetAllArticles_Hashtag()
        {
            var query = _appDbContext.Articles_Hashtags
                .AsQueryable();

            var articles_Hashtag = await query.Select(c => new Articles_HashtagDTO
            {
                Id = c.Id,
                ArcticleID = c.ArcticleID,
                HashtagID = c.HashtagID,
                CreateDate = c.CreateDate,
                ModifiedDate = c.ModifiedDate,
            }).ToListAsync();

            return articles_Hashtag;
        }

        public async Task<Articles_HashtagDTO> GetInfoArticles_HashtagById(int id)
        {
            var query = await _appDbContext.Articles_Hashtags
                .AsQueryable()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (query == null)
            {
                return null;
            }

            return new Articles_HashtagDTO
            {
                ArcticleID = query.ArcticleID,
                HashtagID = query.HashtagID,
                CreateDate = query.CreateDate,
                ModifiedDate = query.ModifiedDate,
            };
        }

        public async Task<ResponseDTO<Articles_HashtagDTO>> UpdateArticles_Hashtag(UpdateArticles_HashtagRespository request)
        {
            if (request == null)
            {
                return new ResponseDTO<Articles_HashtagDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var articles_Hashtag = await _appDbContext.Articles_Hashtags
                .FirstOrDefaultAsync(a => a.Id == request.Id);

                if (articles_Hashtag == null)
                {
                    return new ResponseDTO<Articles_HashtagDTO>
                    {
                        DataResponse = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy bài viết."
                    };
                }

                articles_Hashtag.HashtagID = request.HashtagID;
                articles_Hashtag.ArcticleID = request.ArcticleID;
                articles_Hashtag.CreateDate = request.CreateDate;
                articles_Hashtag.ModifiedDate = request.ModifiedDate;

                _appDbContext.Articles_Hashtags.Update(articles_Hashtag);

                await _appDbContext.SaveChangesAsync();

                return new ResponseDTO<Articles_HashtagDTO>
                {
                    DataResponse = new Articles_HashtagDTO
                    {
                        HashtagID = request.HashtagID,
                        ArcticleID = request.ArcticleID,
                        CreateDate = request.CreateDate,
                        ModifiedDate = request.ModifiedDate,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật hashtag bai viet thành công."
                };
            }
        }
    }
}
