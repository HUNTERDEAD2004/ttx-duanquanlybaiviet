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
        public async Task<ActionResult> Index()
        {
            var ArticlesList = _hashtag.GetAllHashtag();

            return View(ArticlesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetArticlesById = _hashtag.GetInfoHashtagById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateHashtagRequest request)
        {
            var articlesCreate = _hashtag.CreateHashtag(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetArticlesById = await _hashtag.GetInfoHashtagById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateHashtagRequest request)
        {
            var articlesUpdate = await _hashtag.UpdateHashtag(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articlesDelete = await _hashtag.DeleteHashtag(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
