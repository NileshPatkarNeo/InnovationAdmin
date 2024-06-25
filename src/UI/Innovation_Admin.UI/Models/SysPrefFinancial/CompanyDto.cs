using Microsoft.AspNetCore.Mvc;

namespace Innovation_Admin.UI.Models.SysPrefFinancial
{
   
        public class CompanyDto
        {
            public Guid CompanyId { get; set; }

        [Remote(action: "IsCompanyNameUnique", controller: "Common", ErrorMessage = "Company Name is already in use.")]
        public string CompanyName { get; set; }
        }

    
}
