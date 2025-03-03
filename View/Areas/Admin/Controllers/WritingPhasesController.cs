using Domain.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Articles;
using Services.DTO.WritingPhases;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WritingPhasesController : Controller
    {
        // GET: WritingPhasesController
        private readonly IWritingPhasesRespository _wrtingphases;
        public WritingPhasesController(IWritingPhasesRespository wrtingphases)
        {
            _wrtingphases = wrtingphases;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var WritingphasesList = await _wrtingphases.GetAllWP();

            return View(WritingphasesList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetWpById = await _wrtingphases.GetWPById(id);

            return View(GetWpById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(WritingPhasesDTO writingPhasesDTO)
        {
            var WPCreate = await _wrtingphases.CreateWP(writingPhasesDTO);

            return RedirectToAction("Index", WPCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetWPById = await _wrtingphases.GetWPById(id);

            return View(GetWPById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(WritingPhasesDTO writingPhasesDTO)
        {
            var wpUpdate = await _wrtingphases.UpdateWP(writingPhasesDTO);

            return RedirectToAction("Index", wpUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var wpDelete = await _wrtingphases.DeleteWP(id);

            return RedirectToAction("Index", wpDelete);
        }
    }
}
