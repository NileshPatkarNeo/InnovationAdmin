using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Services.IRepositories;
using Innovation_Admin.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Common
{
    public class Common
    {
        private readonly ISysPrefCompanies sysPrefCompanies;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        public Common(ISysPrefCompanies _sysPrefCompanies, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl)
        {
            sysPrefCompanies = _sysPrefCompanies;
            _configuration = configuration;
            _apiBaseUrl = apiBaseUrl;
        }

        public async Task<IEnumerable<SysPrefCompanyDto>> GetAllSysPrefCompanies()
        {
            GetAllSysPrefCompanyResponseModel getAllSysPrefCompanyResponseModel = new GetAllSysPrefCompanyResponseModel();

            getAllSysPrefCompanyResponseModel = await sysPrefCompanies.GetAllSysPrefCompanies();

            if (getAllSysPrefCompanyResponseModel.IsSuccess)
            {
                if (getAllSysPrefCompanyResponseModel != null && getAllSysPrefCompanyResponseModel.Data.Count() > 0)
                {
                    return getAllSysPrefCompanyResponseModel.Data;
                }
            }

            return new List<SysPrefCompanyDto>();
        }

        public async Task<CreateSysPrefCompanyResponseModel> CreateSysPrefCompany(SysPrefCompanyDto company)
        {
            return await sysPrefCompanies.CreateSysPrefCompany(company);
        }


        public async Task<UpdateSysPrefCompanyResponseModel> UpdateSysPrefCompany(SysPrefCompanyDto updatedCompany)
        {
            return await sysPrefCompanies.UpdateSysPrefCompany(updatedCompany);
        }
        public async Task<GetSysPrefCompanyByIdResponseModel> GetSysPrefCompanyById(Guid companyId)
        {
            return await sysPrefCompanies.GetSysPrefCompanyById(companyId);
        }

        public async Task<bool> DeleteSysPrefCompany(Guid companyId)
        {
            return await sysPrefCompanies.DeleteSysPrefCompany(companyId);
        }
    }
}
