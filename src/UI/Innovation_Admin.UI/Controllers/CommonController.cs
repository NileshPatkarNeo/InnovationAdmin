using Innovation_Admin.UI.Models.AdminRole;
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

        public async Task<IActionResult> AdminRole()
        {
            var getAllAdminRoles = await _common.GetAllAdminRoles();
            return View(getAllAdminRoles);
        }

        [HttpGet]
        public IActionResult CreateAdminRole()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdminRole(CreateAdminRoleDto newAdminRole)
        {

            var result = await _common.CreateAdminRole(newAdminRole);

            if (!result.IsSuccess)
            {

                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "An error occurred while creating the AdminRole.");
                }


                return RedirectToAction("AdminRole");
            }


            return RedirectToAction("AdminRole");
        }

        [HttpGet]
        public async Task<IActionResult> EditAdminRole([FromQuery] string adminRoleId)
        {
            var AdminRole = await _common.GetAdminRoleById(Guid.Parse(adminRoleId));
            return View(AdminRole.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdminRole(AdminRoleDto updatedAdminRole)
        {
            var result = await _common.UpdateAdminRole(updatedAdminRole);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedAdminRole); // Return to the edit form with error messages
            }

            return RedirectToAction("AdminRole");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdminRole(Guid adminRoleId)
        {
            var isDeleted = await _common.DeleteAdminRole(adminRoleId);
            if (!isDeleted)
            {

                ModelState.AddModelError(string.Empty, "Failed to delete the company.");
            }
            return RedirectToAction("AdminRole");
        }
    }
}
