﻿using Innovation_Admin.UI.Models.SysPrefCompany;
using Microsoft.AspNetCore.Mvc;
using CommonCall = Innovation_Admin.UI.Common;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.Login;
using Innovation_Admin.UI.Services.IRepositories;

namespace Innovation_Admin.UI.Controllers
{
    public class CommonController : Controller
    {
        private readonly CommonCall.Common _common;
        private readonly IAuthenticationService _authenticationService;


        public CommonController(CommonCall.Common common, IAuthenticationService authenticationService) {

            _common = common;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
               
                return View(request);
            }
            var response = await _authenticationService.AuthenticateAsync(request);
            if (!response.IsAuthenticated || string.IsNullOrEmpty(response.Token))
            {
                 ModelState.AddModelError(string.Empty, response.Message ?? "Authentication failed, please try again.");
                return View(request);
            }
            HttpContext.Session.SetString("JWToken", response.Token);

            return RedirectToAction("SysPrefCompany", "Common");
        }




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
    }
}