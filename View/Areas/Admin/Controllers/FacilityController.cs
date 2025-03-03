using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles;
using Services.DTO.Facility;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilityController : Controller
    {
        private readonly IFacilityRespository _facilityRespository;

        public FacilityController(IFacilityRespository facility)
        {
            _facilityRespository = facility;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var ArticlesList = _facilityRespository.GetAllFacilities();

            return View(ArticlesList);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var GetArticlesById = _facilityRespository.GetInfoFacilitiesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateFacilitiesRequest request)
        {
            var articlesCreate = _facilityRespository.CreateFacilities(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var GetArticlesById = _facilityRespository.GetInfoFacilitiesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public ActionResult Edit(UpdateFacilitiesRequest request)
        {
            var articlesUpdate = _facilityRespository.UpdateFacilities(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public ActionResult Delete(int id)
        {
            var articlesDelete = _facilityRespository.DeleteFacilities(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
