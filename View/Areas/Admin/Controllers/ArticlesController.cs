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
        public ActionResult Index()
        {
            var ArticlesList = _artclesRespository.GetAllArticles();

            return View(ArticlesList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetArticlesById = _artclesRespository.GetInfoArticlesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateArticlesRequest request)
        {
            var articlesCreate = _artclesRespository.CreateArticles(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetArticlesById = _artclesRespository.GetInfoArticlesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public ActionResult Edit(UpdateArticlesRequest request)
        {
            var articlesUpdate = _artclesRespository.UpdateArticles(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public ActionResult Delete(int id)
        {
            var articlesDelete = _artclesRespository.DeleteArticles(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
