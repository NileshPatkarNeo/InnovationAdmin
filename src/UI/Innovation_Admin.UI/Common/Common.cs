using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.ResponsesModel.AdminUser;
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
        private readonly IAdminUser adminUser;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        public Common(ISysPrefCompanies _sysPrefCompanies, IAdminUser _adminUser, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl)
        {
            adminUser = _adminUser;
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

        public async Task<IEnumerable<AdminUserDto>> GetAllAdminUser()
        {
            GetAllAdminUserResponseModel getAllAdminUserResponseModel = new GetAllAdminUserResponseModel();

            getAllAdminUserResponseModel = await adminUser.GetAllAdminUser();

            if (getAllAdminUserResponseModel.IsSuccess)
            {
                if (getAllAdminUserResponseModel != null && getAllAdminUserResponseModel.Data.Count() > 0)
                {
                    return getAllAdminUserResponseModel.Data;
                }
            }

            return new List<AdminUserDto>();
        }

        public async Task<CreateAdminUserResponseModel> CreateAdminUser(CreateAdminUserDto company)
        {
            return await adminUser.CreateAdminUser(company);
        }

        public async Task<UpdateAdminUserResponseModel> UpdateAdminUser(AdminUserDto updatedCompany)
        {
            return await adminUser.UpdateAdminUser(updatedCompany);
        }
        public async Task<GetAdminUserByIdResponseModel> GetAdminUserById(Guid companyId)
        {
            return await adminUser.GetAdminUserById(companyId);
        }

        public async Task<bool> DeleteAdminUser(Guid companyId)
        {
            return await adminUser.DeleteAdminUser(companyId);
        }
    }
}
