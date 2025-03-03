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
        public ActionResult Index()
        {
            var ArticlesList = _articles_HashtagRespository.GetAllArticles_Hashtag();
            return View(ArticlesList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetArticlesById = _articles_HashtagRespository.GetInfoArticles_HashtagById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateArticles_HashtagRespository request)
        {
            var articlesCreate = _articles_HashtagRespository.CreateArticles_Hashtag(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetArticlesById = _articles_HashtagRespository.GetInfoArticles_HashtagById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public ActionResult Edit(UpdateArticles_HashtagRespository request)
        {
            var articlesUpdate = _articles_HashtagRespository.UpdateArticles_Hashtag(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public ActionResult Delete(int id)
        {
            var articlesDelete = _articles_HashtagRespository.DeleteArticles_Hashtag(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
