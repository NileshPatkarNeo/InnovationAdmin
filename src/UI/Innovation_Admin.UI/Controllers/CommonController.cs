﻿using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.AdminRole;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;

using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Filter;

namespace Innovation_Admin.UI.Controllers
{

   [AuthFilter]
    public class CommonController : Controller
    {
        private readonly CommonCall.Common _common;
        private readonly IAuthenticationService _authenticationService;


        public CommonController(CommonCall.Common common, IAuthenticationService authenticationService) {

            _common = common;
            _authenticationService = authenticationService;
        }


        #region HomePage
        public IActionResult HomePage()
        {
            var token = HttpContext.Session.GetString("JWToken");
            return View();
        }
        #endregion



        #region SysPrefCompany

        [HttpGet]
        public async Task<IActionResult> SysPrefCompany()
        {
            var getAllSysPrefCompanies = await _common.GetAllSysPrefCompanies();
            return View(getAllSysPrefCompanies);
        }

        [HttpGet]
        public IActionResult CreateSysPrefCompany()
        {  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSysPrefCompany(SysPrefCompanyDto company)
        {
           
            var result = await _common.CreateSysPrefCompany(company);
            if (!result.IsSuccess)
            {
                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
                }
                return RedirectToAction("SysPrefCompany");
            }
           return RedirectToAction("SysPrefCompany");
        }
          [HttpGet]
        public async Task<IActionResult> EditSysPrefCompany([FromQuery] string companyId)
        {
            var sysPrefCompany = await _common.GetSysPrefCompanyById(Guid.Parse(companyId));
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefCompany(SysPrefCompanyDto updatedCompany)
        {
            var result = await _common.UpdateSysPrefCompany(updatedCompany);
             if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedCompany); 
            }
            return RedirectToAction("SysPrefCompany");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefCompany(Guid companyId)
        {
            var isDeleted = await _common.DeleteSysPrefCompany(companyId);
            if (!isDeleted)
            {
                
                ModelState.AddModelError(string.Empty, "Failed to delete the company.");
            }
         return RedirectToAction("SysPrefCompany");
        }

        #endregion


        #region AdminUser

        public async Task<IActionResult> AdminUser()
        {
            var getAllAdminUser = await _common.GetAllAdminUser();
            return View(getAllAdminUser);
        }


        [HttpGet]
        public IActionResult CreateAdminUser()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdminUser(CreateAdminUserDto company)
        {

            var result = await _common.CreateAdminUser(company);

            if (!result.IsSuccess)
            {

                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
                }


                return RedirectToAction("AdminUser");
            }


            return RedirectToAction("AdminUser");
        }

        [HttpGet]
        public async Task<IActionResult> EditAdminUser([FromQuery] string adminId)
        {
            var sysPrefCompany = await _common.GetAdminUserById(Guid.Parse(adminId));
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdminUser(AdminUserDto updatedAdmin)
        {
            var result = await _common.UpdateAdminUser(updatedAdmin);


            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedAdmin); // Return to the edit form with error messages
            }

            return RedirectToAction("AdminUser");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdminUser(Guid companyId)
        {
            var isDeleted = await _common.DeleteAdminUser(companyId);
            if (!isDeleted)
            {

                ModelState.AddModelError(string.Empty, "Failed to delete the company.");
            }
            return RedirectToAction("AdminUser");
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

        public async Task<IActionResult> CreateAdminRole(CreateAdminRoleDto adminRole)
        {

            var result = await _common.CreateAdminRole(adminRole);

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
            var adminRole = await _common.GetAdminRoleById(Guid.Parse(adminRoleId));
            return View(adminRole.Data);
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

                ModelState.AddModelError(string.Empty, "Failed to delete the adminRole.");
            }
            return RedirectToAction("AdminRole");
        }

        #endregion
    
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
    


 


