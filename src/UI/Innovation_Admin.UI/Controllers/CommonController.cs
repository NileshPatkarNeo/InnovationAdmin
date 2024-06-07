using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.AdminRole;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;

using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Filter;
using Innovation_Admin.UI.Models.PharmacyGroup;
using System.Reflection;

using Innovation_Admin.UI.Models.Account_Manager;
using Innovation_Admin.UI.Models.SysPrefFinancial;
using Microsoft.AspNetCore.Mvc.Rendering;
using Innovation_Admin.UI.Models.SysPrefSecurityEmail;
using System.ComponentModel.Design;
using Innovation_Admin.UI.Services.Repositories;

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
        public async Task<IActionResult>  CreateAdminUser()
        {
            var getAllAdminRoles = await _common.GetAllAdminRoles();
            ViewBag.RoleList = new SelectList(getAllAdminRoles, "Role_ID", "Role_Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminUser(CreateAdminUserDto company)
        {
          
            var result = await _common.CreateAdminUser(company);
            if (result.Message == null)
            {
                TempData["Message"] = "Successfully Added";
                return RedirectToAction("AdminUser");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("AdminUser");
            }
            return RedirectToAction("AdminUser");

        }

        [HttpGet]
        public async Task<IActionResult> EditAdminUser([FromQuery] string adminId)
        {
            var sysPrefCompany = await _common.GetAdminUserById(Guid.Parse(adminId));
            var getAllAdminRoles = await _common.GetAllAdminRoles();
            ViewBag.RoleList = new SelectList(getAllAdminRoles, "Role_ID", "Role_Name");
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdminUser(AdminUserDto updatedAdmin)
        {

            var result = await _common.UpdateAdminUser(updatedAdmin);
            if (result.Message != null)
            {
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("AdminUser");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("AdminUser");
            }
            return RedirectToAction("AdminUser");
  
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdminUser(Guid companyId)
        {

            bool isDeleted = await _common.DeleteAdminUser(companyId);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete." });
            }
  
        }


        #endregion

        #region AdminRole


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
                return View(updatedAdminRole);  
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
            if (!ModelState.IsValid)
            {
                
                return View(company);
            }
            var result = await _common.CreateSysPrefGeneralBehaviour(company);
                return RedirectToAction("SysPrefGeneralBehaviour");
        }

        [HttpGet]
        public async Task<IActionResult> EditSysPrefGeneralBehaviour([FromQuery] string Preference_ID)
        {
            if (string.IsNullOrEmpty(Preference_ID) || !Guid.TryParse(Preference_ID, out Guid prefId))
            {
                return BadRequest("Invalid Preference ID");
            }

            var sysPrefCompany = await _common.GetSysPrefGeneralBehaviourById(prefId);
            if (sysPrefCompany == null || sysPrefCompany.Data == null)
            {
                return NotFound("System Preference General Behaviour not found");
            }

            return View(sysPrefCompany.Data);
        }



        [HttpGet]
        public async Task<IActionResult> SysPrefGeneralBehaviourDetails(Guid Preference_ID)
        {
            if (Preference_ID == Guid.Empty)
            {
                return BadRequest("Preference ID is required");
            }

            var sysPrefGeneralBehaviour = await _common.GetSysPrefGeneralBehaviourById(Preference_ID);
            if (sysPrefGeneralBehaviour == null || sysPrefGeneralBehaviour.Data == null)
            {
                return NotFound("System Preference General Behaviour not found");
            }

            return View(sysPrefGeneralBehaviour.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCompany);  
            }

            var result = await _common.UpdateSysSysPrefGeneralBehaviour(updatedCompany);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedCompany);  
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


        #region PharmacyGroup
        [HttpGet]
        public async Task<IActionResult> PharmacyGroups()
        {
            var getAllgroup = await _common.GetAllPharmcayGroup();
            return View(getAllgroup);
        }


        [HttpGet]
        public IActionResult CreatePharmacyGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePharmacyGroup(PharmacyGroupDto group)
        {
            if (!ModelState.IsValid)
            {
                return View(group); 
            }
            var result = await _common.CreatePharmacyGroup(group);
            if (!result.IsSuccess)
            {
                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the Pharmacy Group.");
                }
                return RedirectToAction("PharmacyGroups");
            }
            return RedirectToAction("PharmacyGroups");
        }

        

        [HttpGet]
        public async Task<IActionResult> EditPharmacyGroup( string Id)
        {
            if (string.IsNullOrEmpty(Id) || !Guid.TryParse(Id, out Guid prefId))
            {
                return BadRequest("Invalid ID");
            }

            var group = await _common.GetPharmacyGroupById(prefId);
            if (group == null || group.Data == null)
            {
                return NotFound("group not found");
            }

            return View(group.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPharmacyGroup(PharmacyGroupDto updatedgroup)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedgroup); 
            }

            var result = await _common.UpdatePharmacyGroup(updatedgroup);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedgroup); 
            }

            return RedirectToAction("PharmacyGroups");
        }



        [HttpPost]
        public async Task<IActionResult> DeletePharmacyGroup(Guid Id)
        {
            var isDeleted = await _common.DeletePharmacyGroup(Id);
            if (!isDeleted)
            {

                ModelState.AddModelError(string.Empty, "Failed to delete the group.");
            }
            return RedirectToAction("PharmacyGroups");
        }


        #endregion


        



        #region Account_Manager

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

        [HttpPost]
        public async Task<IActionResult> DeleteAccountManager(Guid Id)
        {
            var isDeleted = await _common.DeleteAccountManager(Id);
            return RedirectToAction("GetAllAccountManagers");
        }


        #endregion


        #region SysPrefFinancial

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

         [HttpGet]
        public async Task<IActionResult> DetailsSysPrefFinancial(Guid financialID)
        {
            if (financialID == Guid.Empty)
            {
                return BadRequest("Financial ID is required");
            }

            var sysPrefFinancial = await _common.GetSysPrefFinancialById(financialID);
            if (sysPrefFinancial == null || sysPrefFinancial.Data == null)
            {
                return NotFound("System Preference Financial not found");
            }

            return View(sysPrefFinancial.Data);
        }


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

        #endregion

        #region SysPrefSecurityEmail
        public async Task<IActionResult> SysPrefSecurityEmail()
        {
            var getAllSysPrefSecurityEmail = await _common.GetAllSysPrefSecurityEmail();
            return View(getAllSysPrefSecurityEmail);
        }

        [HttpGet]
        public IActionResult CreateSysPrefSecurityEmail()
        {
            return View();
        }

        public async Task<IActionResult> CreateSysPrefSecurityEmail(CreateSysPrefSecurityEmailDto email)
        {
            var result = await _common.CreateSysPrefSecurityEmail(email);
            if (result.Message == null)
            {
                TempData["Message"] = "Successfully Added";
                return RedirectToAction("SysPrefSecurityEmail");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("SysPrefSecurityEmail");
            }
            return RedirectToAction("SysPrefSecurityEmail");

        }

        [HttpGet]
        public async Task<IActionResult> EditSysPrefSecurityEmail([FromQuery] string emailId)
        {
            var sysPrefSecurityEMail = await _common.GetSysPrefSecurityEmailById(Guid.Parse(emailId));
            return View(sysPrefSecurityEMail.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefSecurityEmail(SysPrefSecurityEmailDto updatedAdmin)
        {
            var result = await _common.UpdateSysPrefSecurityEmail(updatedAdmin);
            if (result.Message != null)
            {
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("SysPrefSecurityEmail");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("SysPrefSecurityEmail");
            }
            return RedirectToAction("SysPrefSecurityEmail");

        }


        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefSecurityEmail(Guid emailId)
        {
            bool isDeleted = await _common.DeleteSysPrefSecurityEmail(emailId);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete." });
            }
        }

        #endregion


    }
}
    


 




