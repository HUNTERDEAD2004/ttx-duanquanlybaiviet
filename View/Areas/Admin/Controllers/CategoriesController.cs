using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles;
using Services.DTO.Categories;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRespository _categoriesRespository;

        public CategoriesController(ICategoriesRespository categories)
        {
            _categoriesRespository = categories;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ArticlesList = await _categoriesRespository.GetAllCategories();

            return View(ArticlesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetArticlesById = await _categoriesRespository.GetInfoCategoriesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoriesRequest request)
        {
            var articlesCreate = await _categoriesRespository.CreateCategories(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetArticlesById = await _categoriesRespository.GetInfoCategoriesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateCategoriesRequest request)
        {
            var articlesUpdate = await _categoriesRespository.UpdateCategories(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articlesDelete = await _categoriesRespository.DeleteCategories(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
