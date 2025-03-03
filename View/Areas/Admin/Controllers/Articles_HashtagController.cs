using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles_Hashtag;
using Services.DTO.Categories;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Articles_HashtagController : Controller
    {
        private readonly IArticles_HashtagRespository _articles_HashtagRespository;

        public Articles_HashtagController(IArticles_HashtagRespository articles_Hashtag)
        {
            _articles_HashtagRespository = articles_Hashtag;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ArticlesList = await _articles_HashtagRespository.GetAllArticles_Hashtag();
            return View(ArticlesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetArticlesById = await _articles_HashtagRespository.GetInfoArticles_HashtagById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateArticles_HashtagRespository request)
        {
            var articlesCreate = await _articles_HashtagRespository.CreateArticles_Hashtag(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetArticlesById = await _articles_HashtagRespository.GetInfoArticles_HashtagById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateArticles_HashtagRespository request)
        {
            var articlesUpdate = await _articles_HashtagRespository.UpdateArticles_Hashtag(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articlesDelete = await _articles_HashtagRespository.DeleteArticles_Hashtag(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
