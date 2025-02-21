using Services.DTO.Articles;
using Services.IRespository;
using Domain.Database.AppDbContext;
using AppDomain.Object;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace Domain.Respository
{
    public class ArticlesRespository : IArticlesRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public ArticlesRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<bool> CreateArticles(CreateArticlesRequest request)
        {
            if (request == null) 
            { 
                return false;
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

                return true;
            }
        }

        public Task<bool> DeleteArticles(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticlesDTO>> GetAllArticles()
        {
            var query = _appDbContext.Articles
                .Include(p => p.Articles_Hashtags)
                .Include(p => p.Approvals)
                .AsQueryable();

            var Articles = await query.Select(p => new ArticlesDTO
            { 
                ArcticleID = p.ArcticleID,
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

        public Task<ArticlesDTO> GetInfoArticlesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateArticles(UpdateArticlesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
