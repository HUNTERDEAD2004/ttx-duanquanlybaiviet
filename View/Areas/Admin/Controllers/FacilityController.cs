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
        public async Task<ActionResult> Index()
        {
            var ArticlesList = await _facilityRespository.GetAllFacilities();

            return View(ArticlesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetArticlesById = await _facilityRespository.GetInfoFacilitiesById(id);

            return View(GetArticlesById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFacilitiesRequest request)
        {
            var articlesCreate = await _facilityRespository.CreateFacilities(request);

            return RedirectToAction("Index", articlesCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetArticlesById = await _facilityRespository.GetInfoFacilitiesById(id);

            return View(GetArticlesById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateFacilitiesRequest request)
        {
            var articlesUpdate = await _facilityRespository.UpdateFacilities(request);

            return RedirectToAction("Index", articlesUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articlesDelete = await _facilityRespository.DeleteFacilities(id);

            return RedirectToAction("Index", articlesDelete);
        }
    }
}
