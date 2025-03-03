using AppDomain.Object;
using Common.Response;
using Domain.Data.Enum;
using Domain.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Articles;
using Services.DTO.Categories;
using Services.DTO.Hashtag;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class HashtagRespository : IHashtagRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public HashtagRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<ResponseDTO<HashtagDTO>> CreateHashtag(CreateHashtagRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<HashtagDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var createHashtag = new Hashtag
                {
                    Title = request.Title,
                    CreateDate = request.CreateDate,
                    ModifiedDate = request.ModifiedDate,
                };

                _appDbContext.Hashtags.Add(createHashtag);
                _appDbContext.SaveChanges();

                return new ResponseDTO<HashtagDTO>
                {
                    DataResponse = new HashtagDTO
                    {
                        Title = request.Title,
                        CreateDate = request.CreateDate,
                        ModifiedDate = request.ModifiedDate,
                    },
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo Hashtag thành công."
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteHashtag(int id)
        {
            var deleteHashtag = await _appDbContext.Hashtags.FindAsync(id);
            if (deleteHashtag != null)
            {
                _appDbContext.Hashtags.Remove(deleteHashtag);
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

        public async Task<List<HashtagDTO>> GetAllHashtag()
        {
            var query = _appDbContext.Hashtags
                .Include(c => c.Articles_Hashtags)
                .AsQueryable();

            var Hashtag = await query.Select(c => new HashtagDTO
            {
                Title = c.Title,
                CreateDate  = DateTime.Now,
                ModifiedDate = DateTime.Now,
            }).ToListAsync();

            return Hashtag;
        }

        public async Task<HashtagDTO> GetInfoHashtagById(int id)
        {
            var query = await _appDbContext.Hashtags
               .Include(c => c.Articles_Hashtags)
               .AsQueryable()
               .FirstOrDefaultAsync(a => a.HashtagID == id);

            if (query == null)
            {
                return null;
            }

            return new HashtagDTO
            {
                Title = query.Title,
                CreateDate = query.CreateDate,
                ModifiedDate = query.ModifiedDate,
            };
        }

        public async Task<ResponseDTO<HashtagDTO>> UpdateHashtag(UpdateHashtagRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<HashtagDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var hashtag = await _appDbContext.Hashtags
                .Include(c => c.Articles_Hashtags)
                .FirstOrDefaultAsync(a => a.HashtagID == request.HashtagID);

                if (hashtag == null)
                {
                    return new ResponseDTO<HashtagDTO>
                    {
                        DataResponse = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy Hashtag."
                    };
                }

                hashtag.Title = request.Title;
                hashtag.CreateDate = request.CreateDate;
                hashtag.ModifiedDate = request.ModifiedDate;

                _appDbContext.Hashtags.Update(hashtag);

                await _appDbContext.SaveChangesAsync();

                return new ResponseDTO<HashtagDTO>
                {
                    DataResponse = new HashtagDTO
                    {
                        Title = request.Title,
                        CreateDate = request.CreateDate,
                        ModifiedDate = request.ModifiedDate,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật hasgtag thành công."
                };
            }
        }
    }
}
