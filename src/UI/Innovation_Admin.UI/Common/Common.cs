using Innovation_Admin.UI.Models.AdminRole;
using Innovation_Admin.UI.Models.ResponsesModel.AdminRole;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.SysPrefCompany;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Drawing;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Common
{
    public class Common
    {
        private readonly ISysPrefCompanies sysPrefCompanies;
        private readonly IAdminRoles adminRoles;
        private readonly IConfiguration _configuration;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        public Common(ISysPrefCompanies _sysPrefCompanies, IConfiguration configuration, IOptions<ApiBaseUrl> apiBaseUrl, IAdminRoles _adminRoles)
        {
            sysPrefCompanies = _sysPrefCompanies;
            _configuration = configuration;
            _apiBaseUrl = apiBaseUrl;
            adminRoles = _adminRoles;
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

        #region - AdminRole
        public async Task<IEnumerable<AdminRoleDto>> GetAllAdminRoles()
        {
            GetAllAdminRoleResponseModel getAllAdminRoleResponseModel = new GetAllAdminRoleResponseModel();

            getAllAdminRoleResponseModel = await adminRoles.GetAllAdminRoles();

            if (getAllAdminRoleResponseModel.IsSuccess)
            {
                if (getAllAdminRoleResponseModel != null && getAllAdminRoleResponseModel.Data.Count() > 0)
                {
                    return getAllAdminRoleResponseModel.Data;
                }
            }

            return new List<AdminRoleDto>();
        }
        public async Task<CreateAdminRoleResponseModel> CreateAdminRole(CreateAdminRoleDto newAdminRole)
        {
            return await adminRoles.CreateAdminRole(newAdminRole);
        }

        public async Task<UpdateAdminRoleResponseModel> UpdateAdminRole(AdminRoleDto updatedAdminRole)
        {
            return await adminRoles.UpdateAdminRole(updatedAdminRole);
        }
        public async Task<GetAdminRoleByIdResponseModel> GetAdminRoleById(Guid adminRoleId)
        {
            return await adminRoles.GetAdminRoleById(adminRoleId);
        }

        public async Task<bool> DeleteAdminRole(Guid adminRoleId)
        {
            return await adminRoles.DeleteAdminRole(adminRoleId);
        }
        #endregion
    }
}
