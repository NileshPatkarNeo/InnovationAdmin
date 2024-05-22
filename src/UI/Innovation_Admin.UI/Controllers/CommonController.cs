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
    }
}
