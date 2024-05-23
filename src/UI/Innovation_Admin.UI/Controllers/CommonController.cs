using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;
namespace Innovation_Admin.UI.Controllers
{
    public class CommonController : Controller
    {
        private readonly CommonCall.Common _common;
        public CommonController(CommonCall.Common common) {

            _common = common;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SysPrefCompany()
        {
            var getAllSysPrefCompanies = await _common.GetAllSysPrefCompanies();
            return View(getAllSysPrefCompanies);
        }

        public async Task<IActionResult> SysPrefGeneralBehaviour()
        {
            var getAllSysPrefCompanies = await _common.GetAllSysPrefBehaviouries();
            return View(getAllSysPrefCompanies);
        }





        [HttpGet]
        public IActionResult CreateSysPrefGeneralBehaviour()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateSysPrefGeneralBehaviour(CreateSysPrefGeneralBehaviourDto company)
        {

            var result = await _common.CreateSysPrefGeneralBehaviour(company);

            if (!result.IsSuccess)
            {

                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefGeneralBehaviour.");
                }


                return RedirectToAction("SysPrefGeneralBehaviour");
            }


            return RedirectToAction("SysPrefGeneralBehaviour");
        }



        [HttpGet]
        public async Task<IActionResult> EditSysPrefGeneralBehaviour([FromQuery] string Preference_ID)
        {
            var sysPrefCompany = await _common.GetSysPrefGeneralBehaviourById(Guid.Parse(Preference_ID));
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany)
        {
            var result = await _common.UpdateSysSysPrefGeneralBehaviour(updatedCompany);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedCompany); // Return to the edit form with error messages
            }

            return RedirectToAction("SysPrefGeneralBehaviour");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefGeneralBehaviour(Guid Preference_ID)
        {
            var isDeleted = await _common.DeleteSysPrefGeneralBehaviour(Preference_ID);
            if (!isDeleted)
            {

                ModelState.AddModelError(string.Empty, "Failed to delete the GeneralBehaviour.");
            }
            return RedirectToAction("SysPrefGeneralBehaviour");
        }

    }
}


