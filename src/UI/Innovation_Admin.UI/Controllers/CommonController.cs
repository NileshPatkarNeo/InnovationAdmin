using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.AdminRole;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;

using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Filter;
using Innovation_Admin.UI.Models.Account_Manager;
using Innovation_Admin.UI.Models.SysPrefFinancial;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Innovation_Admin.UI.Controllers
{

    //  [AuthFilter]
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
            return RedirectToAction("SysPrefCompany");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefCompany(Guid companyId)
        {
            var isDeleted = await _common.DeleteSysPrefCompany(companyId);
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



        #region SysPrefGeneralBehaviour

       
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
        #endregion



        #region Lookup_Table_Account_Manager

        [HttpGet]
        public async Task<IActionResult> GetAllAccountManagers()
        {
            var accountManagers = await _common.GetAllAccountManagers();
            return View(accountManagers);
        }

        [HttpGet]
        public IActionResult CreateAccountManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccountManager(AccountManagerDto manager)
        {
            var result = await _common.CreateAccountManager(manager);
           
            return RedirectToAction("GetAllAccountManagers");
        }



        [HttpGet]
        public async Task<IActionResult> EditAccountManager( string Id)
        {
            var accountManager = await _common.GetAccountManagerById(Guid.Parse(Id));
            return View(accountManager.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccountManager(AccountManagerDto manager)
        {
            var result = await _common.UpdateAccountManager(manager);
            return RedirectToAction("GetAllAccountManagers");
        }


        [HttpGet]
        public async Task<IActionResult> SysPrefFinancial()
        {
            var getAllSysPrefFinancials = await _common.GetAllSysPrefFinancials();
            return View(getAllSysPrefFinancials);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSysPrefFinancial()
        {
            var sysPrefCompanies = await _common.GetAllSysPrefCompanies();
            ViewBag.CompanyList = new SelectList(sysPrefCompanies, "CompanyID", "CompanyName");
            return View();
        }


        //[HttpGet]
        //public IActionResult CreateSysPrefFinancial()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateSysPrefFinancial(SysPrefFinancialDto financial)
        {
            var result = await _common.CreateSysPrefFinancial(financial);
            if (!result.IsSuccess)
            {
                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefFinancial.");
                }
                return RedirectToAction("SysPrefFinancial");
            }
            return RedirectToAction("SysPrefFinancial");
        }

        [HttpGet]
        public async Task<IActionResult> EditSysPrefFinancial([FromQuery] string financialId)
        {
            var sysPrefFinancial = await _common.GetSysPrefFinancialById(Guid.Parse(financialId));
            var sysPrefCompanies = await _common.GetAllSysPrefCompanies();
            ViewBag.CompanyList = new SelectList(sysPrefCompanies, "CompanyID", "CompanyName");
            return View(sysPrefFinancial.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefFinancial(SysPrefFinancialDto updatedFinancial)
        {
            var result = await _common.UpdateSysPrefFinancial(updatedFinancial);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedFinancial);
            }
            return RedirectToAction("SysPrefFinancial");
        }

        //[HttpGet]
        //public async Task<IActionResult> EditSysPrefFinancial([FromQuery] string financialId)
        //{
        //    var sysPrefFinancial = await _common.GetSysPrefFinancialById(Guid.Parse(financialId));
        //    if (sysPrefFinancial == null)
        //    {
        //        return NotFound();
        //    }

        //    // Retrieve the list of companies from your repository
        //    var companies = await _common.GetCompanies();
        //    ViewBag.CompanyList = companies.Select(c => new { Value = c.CompanyId, Text = c.CompanyName }).ToList();

        //    return View(sysPrefFinancial.Data);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditSysPrefFinancial(SysPrefFinancialDto updatedFinancial)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Retrieve the list of companies again if model state is invalid
        //        var companies = await _common.GetCompanies();
        //        ViewBag.CompanyList = companies.Select(c => new { Value = c.CompanyId, Text = c.CompanyName }).ToList();
        //        return View(updatedFinancial);
        //    }

        //    var result = await _common.UpdateSysPrefFinancial(updatedFinancial);
        //    if (!result.IsSuccess)
        //    {
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        // Retrieve the list of companies again if update failed
        //        var companies = await _common.GetCompanies();
        //        ViewBag.CompanyList = companies.Select(c => new { Value = c.CompanyId, Text = c.CompanyName }).ToList();
        //        return View(updatedFinancial);
        //    }
        //    return RedirectToAction("SysPrefFinancial");
        //}


        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefFinancial(Guid financialId)
        {
            var isDeleted = await _common.DeleteSysPrefFinancial(financialId);
            if (!isDeleted)
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the financial record.");
            }
            return RedirectToAction("SysPrefFinancial");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccountManager(Guid Id)
        {
            var isDeleted = await _common.DeleteAccountManager(Id);
            return RedirectToAction("GetAllAccountManagers");
        }


        #endregion



    }
}
    


 




