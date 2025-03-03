using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles;
using Services.DTO.Hashtag;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HashtagController : Controller
    {
        private readonly IHashtagRespository _hashtag;

        public HashtagController(IHashtagRespository hashtagRespository)
        {
            _hashtag = hashtagRespository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var ArticlesList = _hashtag.GetAllHashtag();

            return View(ArticlesList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetArticlesById = _hashtag.GetInfoHashtagById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateHashtagRequest request)
        {
            var articlesCreate = _hashtag.CreateHashtag(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetArticlesById = _hashtag.GetInfoHashtagById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public ActionResult Edit(UpdateHashtagRequest request)
        {
            var articlesUpdate = _hashtag.UpdateHashtag(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public ActionResult Delete(int id)
        {
            var articlesDelete = _hashtag.DeleteHashtag(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
