using AppDomain.Object;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.RegistrationPeriods;
using Services.DTO.WritingPhases;
using Services.IRespository;

namespace View.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistrationPeriodsController : Controller
    {
        private readonly IRegistrationPeriodsRespository _registrationPeriods;
        public RegistrationPeriodsController(IRegistrationPeriodsRespository registrationPeriods)
        {
            _registrationPeriods = registrationPeriods;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var registrationPeriodsList = await _registrationPeriods.GetAllRegistrations();

            return View(registrationPeriodsList);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var GetRPById = await _registrationPeriods.GetRegistrationsById(id);

            return View(GetRPById);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegistrationPeriodsDTO registrationPeriodsDTO)
        {
            var RPCreate = await _registrationPeriods.CreateRegistrationPe(registrationPeriodsDTO);

            return RedirectToAction("Index", RPCreate);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var GetRPById = await _registrationPeriods.GetRegistrationsById(id);

            return View(GetRPById);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RegistrationPeriodsDTO registrationPeriodsDTO)
        {
            var rpUpdate = await _registrationPeriods.UpdateRegistrationPe(registrationPeriodsDTO);

            return RedirectToAction("Index", rpUpdate);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var rpDelete = await _registrationPeriods.DeleteRegistrationPe(id);

            return RedirectToAction("Index", rpDelete);
        }
    }
}
