using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.AdminRole;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;
using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Filter;
using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.Account_Manager;
using Innovation_Admin.UI.Models.SysPrefFinancial;
using Microsoft.AspNetCore.Mvc.Rendering;
using Innovation_Admin.UI.Models.SysPrefSecurityEmail;
using Innovation_Admin.UI.Models.Quote;
using Innovation_Admin.UI.Models.RemittanceType;
using Innovation_Admin.UI.Models.ReceiptBatchSource;
using Innovation_Admin.UI.Models.DataSource;
using Innovation_Admin.UI.Models.Template;
using Innovation_Admin.UI.Models.BillingMethodType;
using Innovation_Admin.UI.Models.APAccountType;
using Innovation_Admin.UI.Models.CorrespondenceNote;
using Innovation_Admin.UI.Models.DoNotTakeGroup;
using Innovation_Admin.UI.Models.ContractTerms;
using Innovation_Admin.UI.Models.ClaimStatus;
using Innovation_Admin.UI.Models.CategoryType;
using Innovation_Admin.UI.Models.PharmacyType;

namespace Innovation_Admin.UI.Controllers
{

    [AuthFilter]
    public class CommonController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly CommonCall.Common _common;
        private readonly IAuthenticationService _authenticationService;


        public CommonController(CommonCall.Common common, IAuthenticationService authenticationService, IWebHostEnvironment webHostEnvironment)
        {

            _common = common;
            _authenticationService = authenticationService;
            _webHostEnvironment = webHostEnvironment;
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
            string UserId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(UserId))
            {
                ModelState.AddModelError(string.Empty, "User ID is not found in session.");
                return RedirectToAction("SysPrefCompany");
            }


            var result = await _common.CreateSysPrefCompany(company);
            if (result.Message == null)
            {
                TempData["Message"] = "Successfully Added";
                return RedirectToAction("SysPrefCompany");

            }
            else if (result.Message == "Failed to add company.")
            {
                TempData["Message"] = result.Message;
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
     
        public async Task<IActionResult> EditSysPrefCompany(SysPrefCompanyDto updatedCompany)
        {
            var result = await _common.UpdateSysPrefCompany(updatedCompany);
            if (result.Message != null)
            {
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("SysPrefCompany");

            }
            else if (result.Message == "Failed to Update company.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("SysPrefCompany");
            }
            return RedirectToAction("SysPrefCompany");
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteSysPrefCompany(Guid companyId)
        //{
        //    var isDeleted = await _common.DeleteSysPrefCompany(companyId);
        // return RedirectToAction("SysPrefCompany");
        //}
        [HttpPost]
        public async Task<IActionResult> DeleteSysPrefCompany(Guid companyId)
        {
            bool isDeleted = await _common.DeleteSysPrefCompany(companyId);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the Company Details" });
            }
        }

        #endregion


        #region AdminUser

        public async Task<IActionResult> AdminUser()
        {
            var getAllAdminUser = await _common.GetAllAdminUser();
            return View(getAllAdminUser);
        }

        //[HttpGet]
        //public async Task<JsonResult> IsAdminUserUnique(string user_Name, Guid id)
        //{
        //    var alladmin = await _common.GetAllAdminUser();
        //    var isUnique = !alladmin.Any(admin => admin.User_Name.Equals(user_Name, StringComparison.OrdinalIgnoreCase) && admin.User_ID != id);

        //    return Json(isUnique);
        //}


        public async Task<IActionResult> IsAdminUserUnique(string user_Name, Guid user_ID)
        {
            var allbilling = await _common.GetAllAdminUser();
            bool isUnique = false;
            if (string.IsNullOrEmpty(user_ID.ToString()) || user_ID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbilling.Any(batch => batch.User_Name.Equals(user_Name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbilling.Any(batch => batch.User_Name.Equals(user_Name, StringComparison.OrdinalIgnoreCase) && batch.User_ID != user_ID);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdminUser()
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


        public async Task<IActionResult> IsRoleNameUnique(string role_Name, Guid role_ID)
        {
            var allRoles = await _common.GetAllAdminRoles();
            bool isUnique = false;
            if (string.IsNullOrEmpty(role_ID.ToString()) || role_ID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allRoles.Any(role => role.Role_Name.Equals(role_Name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allRoles.Any(role => role.Role_Name.Equals(role_Name, StringComparison.OrdinalIgnoreCase) && role.Role_ID != role_ID);
            }

            return Json(isUnique);
        }



        [HttpGet]
        public IActionResult CreateAdminRole()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdminRole(CreateAdminRoleDto adminRole)
        {

            var result = await _common.CreateAdminRole(adminRole);

            if (result.Message == null)
            {
                TempData["Message"] = "Admin Role Successfully Added";
                return RedirectToAction("AdminRole");

            }
            else if (result.Message == "Failed to add role.")
            {
                TempData["Message"] = result.Message;
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

            if (result.Message == null)
            {
                TempData["Message"] = "Admin Role Successfully Updated ";
                return RedirectToAction("AdminRole");

            }
            else if (result.Message == "Failed to Update role.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("AdminRole");
            }

            return RedirectToAction("AdminRole");
        }



        [HttpPost]
        public async Task<IActionResult> DeleteAdminRole(Guid adminRoleId)
        {
            bool isDeleted = await _common.DeleteAdminRole(adminRoleId);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the admin role." });
            }
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
            if (result.Message == null)
            {
                TempData["Message"] = "General Behaviour Successfully Added";
                return RedirectToAction("SysPrefGeneralBehaviour");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("SysPrefGeneralBehaviour");
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany)
        {
            var result = await _common.UpdateSysSysPrefGeneralBehaviour(updatedCompany);

            if (result.Message != null)
            {
                TempData["Message"] = "General Behaviour Successfully Updated";
                return RedirectToAction("SysPrefGeneralBehaviour");

            }
            else if (result.Message == "Failed to update.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("SysPrefGeneralBehaviour");
            }

            return RedirectToAction("SysPrefGeneralBehaviour");
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
        public async Task<IActionResult> DeleteSysPrefGeneralBehaviour(Guid Preference_ID)
        {
            bool isDeleted = await _common.DeleteSysPrefGeneralBehaviour(Preference_ID);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the admin role." });
            }

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
            if (result.Message == null)
            {
                TempData["Message"] = "Pharmacy Name Successfully Added";
                return RedirectToAction("PharmacyGroups");

            }
            else if (result.Message == "Failed to add group.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("PharmacyGroups");
            }
            return RedirectToAction("PharmacyGroups");
        }



        [HttpGet]
        public async Task<IActionResult> EditPharmacyGroup(string Id)
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

            if (result.Message != null)
            {
                TempData["Message"] = "Pharmacy Name Successfully Updated";
                return RedirectToAction("PharmacyGroups");

            }
            else if (result.Message == "Failed to add group.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("PharmacyGroups");
            }

            return RedirectToAction("PharmacyGroups");
        }



        [HttpPost]
        public async Task<IActionResult> DeletePharmacyGroup(Guid Id)
        {

            bool isDeleted = await _common.DeletePharmacyGroup(Id);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> IsPharmacyNameUnique(string name, Guid id)
        {
            var allGroups = await _common.GetAllPharmcayGroup();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allGroups.Any(batch => batch.PharmacyName.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allGroups.Any(batch => batch.PharmacyName.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            }

            return Json(isUnique);
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
        public async Task<IActionResult> EditAccountManager(string Id)
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
            if (isDeleted)
            {
                return Json(new {success = true});
            }
            else
            {
                return Json(new { success = false, message="Failed to delete" });
            }
           
        }


        #endregion


        #region SysPrefFinancial

        [HttpGet]
        public async Task<IActionResult> SysPrefFinancial()
        {
            var getAllSysPrefFinancials = await _common.GetAllSysPrefFinancials();
            return View(getAllSysPrefFinancials);
        }
        public async Task<JsonResult> IsCompanyNameUnique(string companyName, Guid id)
        {
            var allFinancials = await _common.GetAllSysPrefFinancials();
            bool isUnique = false;

            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Empty || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allFinancials.Any(financial => financial.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allFinancials.Any(financial => financial.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase) && financial.CompanyID != id);
            }

            return Json(isUnique);
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

                TempData["Message"] = "Financial Successfully Added";

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
            TempData["Message"] = " Financial Successfully Updated ";

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
            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the financial." });
            }
        }

        #endregion



        #region SysPrefSecurityEmail
        public async Task<IActionResult> SysPrefSecurityEmail()
        {
            var getAllSysPrefSecurityEmail = await _common.GetAllSysPrefSecurityEmail();
            return View(getAllSysPrefSecurityEmail);
        }

        public async Task<IActionResult> IsSecurityEmailUnique(string defaultFromName, Guid sysPrefSecurityEmailId)
        {
            var allbilling = await _common.GetAllSysPrefSecurityEmail();
            bool isUnique = false;
            if (string.IsNullOrEmpty(sysPrefSecurityEmailId.ToString()) || sysPrefSecurityEmailId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbilling.Any(batch => batch.DefaultFromName.Equals(defaultFromName, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbilling.Any(batch => batch.DefaultFromName.Equals(defaultFromName, StringComparison.OrdinalIgnoreCase) && batch.SysPrefSecurityEmailId != sysPrefSecurityEmailId);

            }

            return Json(isUnique);
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



        #region Quotes

        public async Task<IActionResult> Quotes()
        {
            var getAllQuotes = await _common.GetAllQuotes();
            return View(getAllQuotes);
        }

        [HttpGet]
        public IActionResult CreateQuote()
        {
            return View();
        }

        public async Task<IActionResult> IsNameUnique(string name, Guid id)
        {
            var allQuotes = await _common.GetAllQuotes();
            bool isUnique = false;

            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allQuotes.Any(quote => quote.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allQuotes.Any(quote => quote.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && quote.ID != id);
            }

            return Json(isUnique);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuote(CreateQuoteDto quote)
        {
            var result = await _common.CreateQuote(quote);

            if (result.Data is null)
            {
                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the quote.");
                }
                TempData["Message"] = "Quotes Successfully Added";

                return RedirectToAction("Quotes");
            }

            return RedirectToAction("Quotes");
        }

        [HttpGet]
        public async Task<IActionResult> EditQuote([FromQuery] string quoteId)
        {
            var quote = await _common.GetQuoteById(Guid.Parse(quoteId));
            return View(quote.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuote(QuoteDto updatedQuote)
        {
            var result = await _common.UpdateQuote(updatedQuote);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedQuote);
            }

            TempData["Message"] = "Quotes Successfully Updated";


            return RedirectToAction("Quotes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuote(Guid quoteId)
        {
            var isDeleted = await _common.DeleteQuote(quoteId);

            if (isDeleted)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the quote." });
            }
        }

        #endregion


        #region RemittanceType

        [HttpGet]
        public async Task<IActionResult> RemittanceTypes()
        {
            var getAllType = await _common.GetAllRemittanceType();
            return View(getAllType);
        }


        [HttpGet]
        public IActionResult CreateRemittanceType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRemittanceType(RemittanceTypeDto type)
        {
            if (!ModelState.IsValid)
            {
                return View(type);
            }
            var result = await _common.CreateRemittanceType(type);
            if (result.Message == null)
            {
                TempData["Message"] = "Remittance Type Successfully Added";
                return RedirectToAction("RemittanceTypes");

            }
            else if (result.Message == "Failed to add type.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("RemittanceTypes");
            }
            return RedirectToAction("RemittanceTypes");

        }

        [HttpGet]
        public async Task<IActionResult> EditRemittanceType(string Id)
        {
            if (string.IsNullOrEmpty(Id) || !Guid.TryParse(Id, out Guid prefId))
            {
                return BadRequest("Invalid ID");
            }

            var type = await _common.GetRemittanceTypeById(prefId);
            if (type == null || type.Data == null)
            {
                return NotFound("type not found");
            }

            return View(type.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRemittanceType(RemittanceTypeDto updatedtype)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedtype);
            }

            var result = await _common.UpdateRemittanceType(updatedtype);

            if (result.Message != null)
            {
                TempData["Message"] = "Remittance Type Successfully Updated";
                return RedirectToAction("RemittanceTypes");

            }
            else if (result.Message == "Failed to add group.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("RemittanceTypes");
            }

            return RedirectToAction("RemittanceTypes");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRemittanceType(Guid Id)
        {
            bool isDeleted = await _common.DeleteRemittanceType(Id);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            return RedirectToAction("RemittanceTypes");
        }

        public async Task<IActionResult> IsNameeUnique(string name, Guid id)
        {
            var allbatch = await _common.GetAllRemittanceType();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            }

            return Json(isUnique);
        }


        #endregion


        #region ReceiptBatchSource
        [HttpGet]
        public async Task<IActionResult> ReceiptBatchSource()
        {
            var getAllReceiptBatch = await _common.GetAllReceiptBatchSource();
            return View(getAllReceiptBatch);
        }


        //[HttpGet]
        //public async Task<IActionResult> IsBatchUnique(string name, Guid id)
        //{
        //    var allbatch = await _common.GetAllReceiptBatchSource();
        //    var isUnique = !allbatch.Any(batch => batch.Name == name && batch.Id != id);

        //    return Json(isUnique);
        //}

        public async Task<IActionResult> IsBatchUnique(string name, Guid id)
        {
            var allbatch = await _common.GetAllReceiptBatchSource();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateReceiptBatchSource()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceiptBatchSource(ReceiptBatchSourceDto batch)
        {
            var result = await _common.CreateReceiptBatchSource(batch);
            if (result.Message == null)
            {
                TempData["Message"] = "Receipt Batch Successfully Added";
                return RedirectToAction("ReceiptBatchSource");

            }
            else if (result.Message != "Failed to add Receipt BAtch.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("ReceiptBatchSource");
            }
            return RedirectToAction("ReceiptBatchSource");
        }


        [HttpGet]
        public async Task<IActionResult> EditReceiptBatchSource(string Id)
        {
            var receiptBatchSource = await _common.GetReceiptBatchSourceById(Guid.Parse(Id));
            return View(receiptBatchSource.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditReceiptBatchSource(ReceiptBatchSourceDto updatedBatch)
        {
            var result = await _common.UpdateReceiptBatchSource(updatedBatch);
            if (result.Message == null)
            {
                TempData["Message"] = "Receipt Batch Successfully Updated";
                return RedirectToAction("ReceiptBatchSource");

            }
            else if (result.Message != "Failed to add Receipt Batch.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("ReceiptBatchSource");
            }
            return RedirectToAction("ReceiptBatchSource");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReceiptBatch(Guid Id)
        {
            var isDeleted = await _common.DeleteReceiptBatchSource(Id);
            if (isDeleted)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the template." });
            }
        }

        #endregion


        #region DataSources

        public async Task<IActionResult> DataSource()
        {
            var getAllDataSource = await _common.GetAllDataSource();
            return View(getAllDataSource);
        }

        //[HttpGet]
        //public async Task<IActionResult> IsDataNameUnique(string name, Guid id)
        //{
        //    var allsource = await _common.GetAllDataSource();
        //    var isUnique = !allsource.Any(group => group.Name ==name && group.ID != id);

        //    return Json(isUnique);
        //}

        public async Task<IActionResult> IsDataSourceUnique(string name, Guid id)
        {
            var allbilling = await _common.GetAllDataSource();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbilling.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbilling.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.ID != id);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateDataSource()
        {
            return View();
        }

        public async Task<IActionResult> CreateDataSource(CreateDataSourceDto data)
        {

            if (!ModelState.IsValid)
            {
                return View(data);
            }
            var result = await _common.CreateDataSource(data);
            if (result.Message == null)
            {
                TempData["Message"] = "DataSource Successfully Added";
                return RedirectToAction("DataSource");

            }
            else if (result.Message == "Failed to add DataSource")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("DataSource");
            }
            return RedirectToAction("DataSource");

        }

        [HttpGet]
        public async Task<IActionResult> EditDataSource(string id)
        {
            var dataSource = await _common.GetDataSourceById(Guid.Parse(id));
            return View(dataSource.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDataSource(DataSourceDto updatedData)
        {
            var result = await _common.UpdateDataSource(updatedData);
            if (result.Message != null)
            {
                TempData["Message"] = "DataSource Successfully Updated";
                return RedirectToAction("DataSource");

            }
            else if (result.Message == "Failed to add DataSource.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("DataSource");
            }
            return RedirectToAction("DataSource");


        }


        [HttpPost]
        public async Task<IActionResult> DeleteDataSource(Guid dataId)
        {
            var isDeleted = await _common.DeleteDataSource(dataId);

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

        #region BillingMethodType

        public async Task<IActionResult> BillingMethodType()
        {
            var getAllBillingMethodType = await _common.GetAllBillingMethodType();
            return View(getAllBillingMethodType);
        }

        //[HttpGet]
        //public async Task<IActionResult> IsBillingMethodTypeUnique(string name, Guid id)
        //{
        //    var allBilling = await _common.GetAllBillingMethodType();
        //    var isUnique = !allBilling.Any(billing => billing.Name == name && billing.ID != id);

        //    return Json(isUnique);
        //}

        public async Task<IActionResult> IsBillingMethodTypeUnique(string name, Guid id)
        {
            var allbilling = await _common.GetAllBillingMethodType();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbilling.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbilling.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.ID != id);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateBillingMethodType()
        {
            return View();
        }

        public async Task<IActionResult> CreateBillingMethodType(CreateBillingMethodTypeDto billing)
        {

            if (!ModelState.IsValid)
            {
                return View(billing);
            }
            var result = await _common.CreateBillingMethodType(billing);
            if (result.Message == null)
            {
                TempData["Message"] = "BillingMethodType Successfully Added";
                return RedirectToAction("BillingMethodType");

            }
            else if (result.Message == "Failed to add BillingMethodType.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("BillingMethodType");
            }
            return RedirectToAction("BillingMethodType");

        }

        [HttpGet]
        public async Task<IActionResult> EditBillingMethodType(string id)
        {
            var billingMethodType = await _common.GetBillingMethodTypeById(Guid.Parse(id));
            return View(billingMethodType.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBillingMethodType(BillingMethodTypeDto updatedBillingMethodType)
        {
            var result = await _common.UpdateBillingMethodType(updatedBillingMethodType);
            if (result.Message != null)
            {
                TempData["Message"] = "BillingMethodType Successfully Updated";
                return RedirectToAction("BillingMethodType");

            }
            else if (result.Message == "Failed to add BillingMethodType.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("BillingMethodType");
            }
            return RedirectToAction("BillingMethodType");


        }


        [HttpPost]
        public async Task<IActionResult> DeleteBillingMethodType(Guid billingMethodTypeId)
        {
            var isDeleted = await _common.DeleteBillingMethodType(billingMethodTypeId);

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


        #region APAccountType

        public async Task<IActionResult> APAccountType()
        {
            var getAllAPAccountType = await _common.GetAllAPAccountType();
            return View(getAllAPAccountType);
        }

        //[HttpGet]
        //public async Task<IActionResult> IsAPAccountNameUnique(string name, Guid id)
        //{
        //    var allaacount = await _common.GetAllAPAccountType();
        //    var isUnique = !allaacount.Any(account => account.Name == name && account.ID != id);

        //    return Json(isUnique);
        //}

        public async Task<IActionResult> IsAPAccountNameUnique(string name, Guid id)
        {
            var allaccount = await _common.GetAllAPAccountType();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allaccount.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allaccount.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.ID != id);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateAPAccountType()
        {
            return View();
        }

        public async Task<IActionResult> CreateAPAccountType(CreateAPAccountTypeDto apaccount)
        {

            if (!ModelState.IsValid)
            {
                return View(apaccount);
            }
            var result = await _common.CreateAPAccountType(apaccount);
            if (result.Message == null)
            {
                TempData["Message"] = "APAccountType Successfully Added";
                return RedirectToAction("APAccountType");

            }
            else if (result.Message == "Failed to add APAccountType.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("APAccountType");
            }
            return RedirectToAction("APAccountType");

        }

        [HttpGet]
        public async Task<IActionResult> EditAPAccountType(string id)
        {
            var dataSource = await _common.GetAPAccountTypeById(Guid.Parse(id));
            return View(dataSource.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAPAccountType(APAccountTypeDto updatedaccount)
        {
            var result = await _common.UpdateAPAccountType(updatedaccount);
            if (result.Message != null)
            {
                TempData["Message"] = "APAccountType Successfully Updated";
                return RedirectToAction("APAccountType");

            }
            else if (result.Message == "Failed to add APAccountType.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("APAccountType");
            }
            return RedirectToAction("APAccountType");


        }


        [HttpPost]
        public async Task<IActionResult> DeleteAPAccountType(Guid accountId)
        {
            var isDeleted = await _common.DeleteAPAccountType(accountId);

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


        #region Templates

        public async Task<IActionResult> Templates()
        {
            var getAllTemplates = await _common.GetAllTemplates();
            return View(getAllTemplates);
        }

        public async Task<IActionResult> IsTemplateNameUnique(string name, Guid id)
        {
            var allTemplates = await _common.GetAllTemplates();
            bool isUnique = false;

            if (id == Guid.Empty || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allTemplates.Any(template => template.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allTemplates.Any(template => template.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && template.ID != id);
            }

            return Json(isUnique);
        }


        [HttpGet]
        public IActionResult CreateTemplate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTemplate(CreateTemplateDto template)
        {
            if (ModelState.IsValid)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(template.PdfFile.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", fileName);
                long fileSizeInBytes = template.PdfFile.Length;
                double fileSizeInKB = (double)fileSizeInBytes / 1024;
                template.Size = fileSizeInKB.ToString("0.00") + " KB";


                template.PdfTemplateFile = "Files/" + fileName;

                var response = await _common.CreateTemplate(template);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await template.PdfFile.CopyToAsync(fileStream);
                }
                TempData["Message"] = "Template Successfully Added";

                return RedirectToAction("Templates");
            }
            else
                ModelState.AddModelError("", "Oops! Some error occured.");

            return View(template);


        }

        [HttpGet]
        public async Task<IActionResult> EditTemplate(Guid templateId)
        {
            var template = await _common.GetTemplateById(templateId);
            return View(template.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTemplate(TemplateDto updatedTemplate)
        {
            if (ModelState.IsValid)
            {
                if (updatedTemplate.PdfFile != null && updatedTemplate.PdfFile.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(updatedTemplate.PdfFile.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", fileName);
                    long fileSizeInBytes = updatedTemplate.PdfFile.Length;
                    double fileSizeInKB = (double)fileSizeInBytes / 1024;
                    updatedTemplate.Size = fileSizeInKB.ToString("0.00") + " KB";

                    updatedTemplate.PdfTemplateFile = "Files/" + fileName;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedTemplate.PdfFile.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    var existingTemplate = await _common.GetTemplateById(updatedTemplate.ID);
                    updatedTemplate.PdfTemplateFile = existingTemplate.Data.PdfTemplateFile;
                    updatedTemplate.Size = existingTemplate.Data.Size;
                }

                var response = await _common.UpdateTemplate(updatedTemplate);
                TempData["Message"] = "Template Successfully Updated";

                return RedirectToAction("Templates");
            }
            else
            {
                ModelState.AddModelError("", "Oops! Some error occurred.");
            }

            return View(updatedTemplate);
        }



        private string GetExistingPdfFilePath(Guid templateId)
        {
            var template = _common.GetTemplateById(templateId).Result.Data;
            return template?.PdfTemplateFile ?? string.Empty;
        }



        [HttpPost]
        public async Task<IActionResult> DeleteTemplate(Guid templateId)
        {
            var isDeleted = await _common.DeleteTemplate(templateId);

            if (isDeleted)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the template." });
            }
        }


        #endregion

        #region CorrespondenceNote

        [HttpGet]
        public async Task<IActionResult> CorrespondenceNotes()
        {
            var getAllNote = await _common.GetAllCorrespondenceNotes();
            return View(getAllNote);
        }

        [HttpGet]
        public IActionResult CreateCorrespondenceNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorrespondenceNote(CreateCorrespondenceNoteDto noteModel)
        {

            if (!ModelState.IsValid)
            {
                return View(noteModel);
            }
            var result = await _common.CreateCorrespondenceNote(noteModel);
            if (result.Message == null)
            {
                TempData["Message"] = "Correspondence Note Successfully Added";
                return RedirectToAction("CorrespondenceNotes");

            }
            else if (result.Message == "Failed to add type.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("CorrespondenceNotes");
            }
            return RedirectToAction("CorrespondenceNotes");


        }

        [HttpGet]
        public async Task<IActionResult> EditCorrespondenceNote(string Id)
        {
            var sysPrefCompany = await _common.GetCorrespondenceNoteById(Guid.Parse(Id));
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCorrespondenceNote(CorrespondenceNoteDto updatedNote)
        {
            var result = await _common.UpdateCorrespondenceNote(updatedNote);
            if (result.Message != null)
            {
                TempData["Message"] = "Correspondence Note Successfully Updated";
                return RedirectToAction("CorrespondenceNotes");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("CorrespondenceNotes");
            }
            return RedirectToAction("CorrespondenceNotes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCorrespondenceNote(Guid noteId)
        {
            var isDeleted = await _common.DeleteCorrespondenceNote(noteId);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete." });
            }
        }


        [HttpGet]
        public async Task<IActionResult> IsNoteUnique(string note, Guid id)
        {
            var allGroups = await _common.GetAllCorrespondenceNotes();
            var isUnique = !allGroups.Any(group => group.Note == note && group.Id != id);

            return Json(isUnique);
        }


        #endregion


        #region DoNotTakeGroup
        [HttpGet]
        public async Task<IActionResult> DoNotTakeGroup()
        {
            var getAllDoNotTakeGroup = await _common.GetAllDoNotTakeGroups();
            return View(getAllDoNotTakeGroup);
        }

        //[HttpGet]
        //public async Task<IActionResult> IsGroupCodeUnique(int groupCode, Guid id)
        //{
        //    var allGroups = await _common.GetAllDoNotTakeGroups();
        //    var isUnique = !allGroups.Any(group => group.GroupCode == groupCode && group.Id != id);
        //    return Json(isUnique);
        //}

        // // Check if a GroupCode is unique
        [HttpGet]
        public async Task<IActionResult> IsGroupCodeUnique(int groupCode, Guid id)
        {
            var allGroups = await _common.GetAllDoNotTakeGroups();
            bool isUnique = false;

            if (id == Guid.Empty)
            {
                isUnique = !allGroups.Any(group => group.GroupCode == groupCode);
            }
            else
            {
                isUnique = !allGroups.Any(group => group.GroupCode == groupCode && group.Id != id);
            }

            return Json(isUnique);
        }


        [HttpGet]
        public IActionResult CreateDoNotTakeGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoNotTakeGroup(DoNotTakeGroupDto group)
        {
            var result = await _common.CreateDoNotTakeGroup(group);
            if (result.Message == null)
            {
                TempData["Message"] = "Successfully Added";
                return RedirectToAction("DoNotTakeGroup");

            }
            else if (result.Message != "Failed to add Receipt BAtch.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("DoNotTakeGroup");
            }
            return RedirectToAction("DoNotTakeGroup");
        }


        [HttpGet]
        public async Task<IActionResult> EditDoNotTakeGroup(string Id)
        {
            var doNotTakeGroup = await _common.GetDoNoTakeGroupById(Guid.Parse(Id));
            return View(doNotTakeGroup.Data);
        }



        [HttpPost]
        public async Task<IActionResult> EditDoNotTakeGroup(DoNotTakeGroupDto updatedgroup)
        {
            var result = await _common.UpdateDoNotTakeGroup(updatedgroup);
            if (result.Message == null)
            {
                TempData["Message"] = "Group updated successfully";
                return RedirectToAction("DoNotTakeGroup");

            }
            else if (result.Message != "Failed to update Group.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("DoNotTakeGroup");
            }
            return RedirectToAction("DoNotTakeGroup");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoNotTakeGroup(Guid Id)
        {
            var isDeleted = await _common.DeleteDoNotTakeGroup(Id);
            if (isDeleted)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the template." });
            }
        }
        #endregion

        #region CategoryType
        public async Task<IActionResult> CategoryType()
        {
            var getAllCategoryType = await _common.GetAllCategoryType();
            return View(getAllCategoryType);
        }


        public async Task<IActionResult> IsCategoryTypeUnique(string name, Guid id)
        {
            var allbilling = await _common.GetAllCategoryType();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbilling.Any(batch => batch.DocumentName.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbilling.Any(batch => batch.DocumentName.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.ID != id);

            }

            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateCategoryType()
        {
            return View();
        }

        public async Task<IActionResult> CreateCategoryType(CreateCategoryTypeDto category)
        {

            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var result = await _common.CreateCategoryType(category);
            if (result.Message == null)
            {
                TempData["Message"] = "CategoryType Successfully Added";
                return RedirectToAction("CategoryType");

            }
            else if (result.Message == "Failed to add DataSource")
            { 
                TempData["Message"] = result.Message;
                return RedirectToAction("CategoryType");
            }
            return RedirectToAction("CategoryType");

        }

        [HttpGet]
        public async Task<IActionResult> EditCategoryType(string id)
        {
            var categoryType = await _common.GetCategoryTypeById(Guid.Parse(id));
            return View(categoryType.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoryType(CategoryTypeDto updatedCategory)
        {
            var result = await _common.UpdateCategoryType(updatedCategory);
            if (result.Message != null)
            {
                TempData["Message"] = "CategoryType Successfully Updated";
                return RedirectToAction("DataSource");

            }
            else if (result.Message == "Failed to add DataSource.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("CategoryType");
            }
            return RedirectToAction("CategoryType");


        }


        [HttpPost]
        public async Task<IActionResult> DeleteCategoryType(Guid categoryId)
        {
            var isDeleted = await _common.DeleteCategoryType(categoryId);

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

        #region PharmacyType

        [HttpGet]
        public async Task<IActionResult> PharmacyTypes()
        {
            var getAlltype = await _common.GetAllPharmcayType();
            return View(getAlltype);
        }


        [HttpGet]
        public IActionResult CreatePharmacyType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePharmacyType(PharmacyTypeDto group)
        {

            if (!ModelState.IsValid)
            {
                return View(group);
            }
            var result = await _common.CreatePharmacyType(group);
            if (result.Message == null)
            {
                TempData["Message"] = "Pharmacy Type Successfully Added";
                return RedirectToAction("PharmacyTypes");

            }
            else if (result.Message == "Failed to add type.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("PharmacyTypes");
            }
            return RedirectToAction("PharmacyTypes");

        }

        [HttpGet]
        public async Task<IActionResult> EditPharmacyType(string Id)
        {
            var sysPrefCompany = await _common.GetPharmacyTypeById(Guid.Parse(Id));
            return View(sysPrefCompany.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPharmacyType(PharmacyTypeDto updatedNote)

        {
            var result = await _common.UpdatePharmacyType(updatedNote);
            if (result.Message != null)
            {
                TempData["Message"] = "Pharmacy Type Successfully Updated";
                return RedirectToAction("PharmacyTypes");

            }
            else if (result.Message == "Failed to add.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("PharmacyTypes");
            }
            return RedirectToAction("PharmacyTypes");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePharmacyType( Guid Id)
        {

            bool isDeleted = await _common.DeletePharmacyType(Id);

            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete." });
            }
        }


        public async Task<IActionResult> IsPharmacyTypeUnique(string description, Guid id)
        {
            var allbatch = await _common.GetAllPharmcayType();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbatch.Any(batch => batch.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbatch.Any(batch => batch.Description.Equals(description, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            }

            return Json(isUnique);
        }

        public async Task<IActionResult> IsPharmacyCodeUnique(int code, Guid id)
        {
            var allPharmacyTypes = await _common.GetAllPharmcayType();
            bool isUnique = false;

            if (id == Guid.Empty || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allPharmacyTypes.Any(pharmacyType => pharmacyType.Code == code);
            }
            else
            {
                isUnique = !allPharmacyTypes.Any(pharmacyType => pharmacyType.Code == code && pharmacyType.Id != id);
            }

            return Json(isUnique);
        }







        #endregion

        #region ContractTerms
        public async Task<IActionResult> ContractTerms()
        {
            var getAllContractTerms = await _common.GetAllContractTerms();
            return View(getAllContractTerms);
        }

        [HttpGet]
        public IActionResult CreateContractTerm()
        {
            return View();
        }

        public async Task<IActionResult> IsContractTermNameUnique(string name, Guid id)
        {
            var allContractTerms = await _common.GetAllContractTerms();
            bool isUnique = false;

            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allContractTerms.Any(contractTerm => contractTerm.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allContractTerms.Any(contractTerm => contractTerm.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && contractTerm.ID != id);
            }

            return Json(isUnique);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContractTerm(CreateContractTermDto contractTerm)
        {
            var result = await _common.CreateContractTerm(contractTerm);

            if (result.Data is null)
            {
                if (result.Message != null)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the contract term.");
                }
                TempData["Message"] = "Contract Term Successfully Added";

                return RedirectToAction("ContractTerms");
            }

            return RedirectToAction("ContractTerms");
        }

        [HttpGet]
        public async Task<IActionResult> EditContractTerm([FromQuery] string contractTermId)
        {
            var contractTerm = await _common.GetContractTermById(Guid.Parse(contractTermId));
            return View(contractTerm.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContractTerm(ContractTermDto updatedContractTerm)
        {
            var result = await _common.UpdateContractTerm(updatedContractTerm);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(updatedContractTerm);
            }

            TempData["Message"] = "Contract Term Successfully Updated";

            return RedirectToAction("ContractTerms");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContractTerm(Guid contractTermId)
        {
            var isDeleted = await _common.DeleteContractTerm(contractTermId);

            if (isDeleted)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the contract term." });
            }
        }
        #endregion

        #region CliamStatus

        [HttpGet]
        public async Task<IActionResult> ClaimStatus()
        {
            var getAllClaimStatus = await _common.GetAllClaimStatus();
            return View(getAllClaimStatus);
        }


        public async Task<IActionResult> IsStatusUnique(string name, Guid id)
        {
            var allbatch = await _common.GetAllClaimStatus();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbatch.Any(batch => batch.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            }

            return Json(isUnique);
        }

        public async Task<IActionResult> IsColorUnique(string color, Guid id)
        {
            var allbatch = await _common.GetAllClaimStatus();
            bool isUnique = false;
            if (string.IsNullOrEmpty(id.ToString()) || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                isUnique = !allbatch.Any(batch => batch.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                isUnique = !allbatch.Any(batch => batch.Color.Equals(color, StringComparison.OrdinalIgnoreCase) && batch.Id != id);

            } 
            return Json(isUnique);
        }

        [HttpGet]
        public IActionResult CreateClaimStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaimStatus(ClaimStatusDto claim)
        {
            var result = await _common.CreateClaimStatus(claim);
            if (result.Message == null)
            {
                TempData["Message"] = "Claim Status Successfully Added";
                return RedirectToAction("ClaimStatus");
            }
            else if (result.Message != "Failed to add Claim Status.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("ClaimStatus");
            }
            return RedirectToAction("ClaimStatus"); 
        }

        [HttpGet] 
        public async Task<IActionResult> EditClaimStatus(string Id)
        {
            var claimStatus = await _common.GetClaimStatusById(Guid.Parse(Id));
            return View(claimStatus.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditClaimStatus(ClaimStatusDto updatedClaim)
        {
            var result = await _common.UpdateClaimStatus(updatedClaim);
            if (result.Message == null)
            {
                TempData["Message"] = "Claim Status Successfully Updated";
                return RedirectToAction("ClaimStatus");
            }
            else if (result.Message != "Failed to add Claim Status.")
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("ClaimStatus");
            }
            return RedirectToAction("ClaimStatus");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClaimStatus(Guid Id)
        {
            var isDeleted = await _common.DeleteClaimStatus(Id);
            if (isDeleted)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the template." });
            }
        }
        #endregion





    }
}








