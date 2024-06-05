using Microsoft.AspNetCore.Mvc;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.Login;
using Innovation_Admin.UI.Services.IRepositories;

namespace Innovation_Admin.UI.Controllers
{
    public class AccountController : Controller
    {
      
        private readonly IAuthenticationService _authenticationService;


        public AccountController(IAuthenticationService authenticationService)
        {

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
            HttpContext.Session.SetString("Token", response.Token);

            return RedirectToAction("HomePage", "Common");
        }

        [HttpGet]
        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();
           
            return RedirectToAction("Index", "Home");
        }

    }
}
