using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IArticlesRespository _artclesRespository;

        public ArticlesController(IArticlesRespository articles)
        {
            _artclesRespository = articles;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ArticlesList = await _artclesRespository.GetAllArticles();

            return View(ArticlesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetArticlesById = await _artclesRespository.GetInfoArticlesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateArticlesRequest request)
        {
            var articlesCreate = await _artclesRespository.CreateArticles(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetArticlesById = await _artclesRespository.GetInfoArticlesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateArticlesRequest request)
        {
            var articlesUpdate = await _artclesRespository.UpdateArticles(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articlesDelete = await _artclesRespository.DeleteArticles(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
