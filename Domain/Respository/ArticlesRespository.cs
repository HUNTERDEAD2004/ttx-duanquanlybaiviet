using Services.DTO.Articles;
using Services.IRespository;
using Domain.Database.AppDbContext;
using AppDomain.Object;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Common.Response;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Domain.Respository
{
    public class ArticlesRespository : IArticlesRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public ArticlesRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<ResponseDTO<ArticlesDTO>> CreateArticles(CreateArticlesRequest request)
        {
            if (request == null) 
            {
                return new ResponseDTO<ArticlesDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var createArticles = new Articles
                {
                    Title = request.Title,
                    Content = request.Content,
                    EmailFe = request.EmailFe,
                    Royalty = request.Royalty,
                    Download_path = request.Download_path,
                    Description = request.Description,
                    Preview_Image = request.Preview_Image,
                    CreateDate = request.CreateDate,
                    ModifiedDate = request.ModifiedDate,
                    CategoryID = request.CategoryID,
                    AuthorID = request.AuthorID,    
                    WritingPhaseID = request.WritingPhaseID
                };

                _appDbContext.Articles.Add(createArticles);
                _appDbContext.SaveChanges();

                return new ResponseDTO<ArticlesDTO>
                {
                    DataResponse = new ArticlesDTO
                    {
                        Title = request.Title,
                        Content = request.Content,
                        EmailFe = request.EmailFe,
                        Royalty = request.Royalty,
                        Download_path = request.Download_path,
                        Description = request.Description,
                        Preview_Image = request.Preview_Image,
                        CreateDate = request.CreateDate,
                        ModifiedDate = request.ModifiedDate,
                        CategoryID = request.CategoryID,
                        AuthorID = request.AuthorID,
                        WritingPhaseID = request.WritingPhaseID
                    },
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo sản phẩm thành công."
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteArticles(int id)
        {
            var deleteArticles = await _appDbContext.Articles.FindAsync(id);
            if (deleteArticles != null)
            {
                _appDbContext.Articles.Remove(deleteArticles);
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

        public async Task<List<ArticlesDTO>> GetAllArticles()
        {
            var query = _appDbContext.Articles
                .Include(p => p.Articles_Hashtags)
                .Include(p => p.Approvals)
                .AsQueryable();

            var Articles = await query.Select(p => new ArticlesDTO
            { 
                ArcticleID = p.ArticleID,
                Title = p.Title,
                Content = p.Content,
                EmailFe = p.EmailFe,
                Royalty = p.Royalty,
                Download_path = p.Download_path,
                Description = p.Description,
                Preview_Image = p.Preview_Image,
                CreateDate = p.CreateDate,
                ModifiedDate = p.ModifiedDate,
                CategoryID = p.CategoryID,
                AuthorID = p.AuthorID,
                WritingPhaseID = p.WritingPhaseID,
            }).ToListAsync();

            return Articles;
        }

        public async Task<ArticlesDTO> GetInfoArticlesById(int id)
        {
            var query = await _appDbContext.Articles
                .Include(p => p.Articles_Hashtags)
                .Include(p => p.Approvals)
                .FirstOrDefaultAsync(a=>a.ArticleID == id);
            if (query == null)
            {
                return null;
            }

            return new ArticlesDTO
            {
                Title = query.Title,
                Content = query.Content,
                EmailFe = query.EmailFe,
                Royalty = query.Royalty,
                Download_path = query.Download_path,
                Description = query.Description,
                Preview_Image = query.Preview_Image,
                CreateDate = query.CreateDate,
                ModifiedDate = query.ModifiedDate,
                CategoryID = query.CategoryID,
                AuthorID = query.AuthorID,
                WritingPhaseID = query.WritingPhaseID,
            };
        }

        public async Task<ResponseDTO<ArticlesDTO>> UpdateArticles(UpdateArticlesRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<ArticlesDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var articles = await _appDbContext.Articles
                    .Include(p => p.Articles_Hashtags)
                    .Include(p => p.Approvals)
                    .FirstOrDefaultAsync(p => p.ArticleID == request.ArcticleID);

                if (articles == null)
                {
                    return new ResponseDTO<ArticlesDTO>
                    {
                        DataResponse = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy bài viết."
                    };
                }

                articles.Title = request.Title;
                articles.Description = request.Description;
                articles.Content = request.Content;
                articles.EmailFe = request.EmailFe;
                articles.Royalty = request.Royalty;
                articles.Download_path = request.Download_path;
                articles.Description = request.Description;
                articles.Preview_Image = request.Preview_Image;
                articles.CreateDate = request.CreateDate;
                articles.ModifiedDate = request.ModifiedDate;
                articles.CategoryID = request.CategoryID;
                articles.AuthorID = request.AuthorID;
                articles.WritingPhaseID = request.WritingPhaseID;

                _appDbContext.Articles.Update(articles);

                await _appDbContext.SaveChangesAsync();

                return new ResponseDTO<ArticlesDTO>
                {
                    DataResponse = new ArticlesDTO
                    {
                        ArcticleID = request.ArcticleID,
                        Title = request.Title,
                        Content = request.Content,
                        EmailFe = request.EmailFe,
                        Royalty = request.Royalty,
                        Download_path = request.Download_path,
                        Description = request.Description,
                        Preview_Image = request.Preview_Image,
                        CreateDate = request.CreateDate,
                        ModifiedDate = request.ModifiedDate,
                        CategoryID = request.CategoryID,
                        AuthorID = request.AuthorID,
                        WritingPhaseID = request.WritingPhaseID
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật bài viết thành công."
                };
            }
        }
    }
}
