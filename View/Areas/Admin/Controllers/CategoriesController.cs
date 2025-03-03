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
        public ActionResult Index()
        {
            var ArticlesList = _categoriesRespository.GetAllCategories();

            return View(ArticlesList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetArticlesById = _categoriesRespository.GetInfoCategoriesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoriesRequest request)
        {
            var articlesCreate = _categoriesRespository.CreateCategories(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetArticlesById = _categoriesRespository.GetInfoCategoriesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public ActionResult Edit(UpdateCategoriesRequest request)
        {
            var articlesUpdate = _categoriesRespository.UpdateCategories(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public ActionResult Delete(int id)
        {
            var articlesDelete = _categoriesRespository.DeleteCategories(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
