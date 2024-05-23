using Innovation_Admin.UI.Models.AdminRole;
using Innovation_Admin.UI.Models.ResponsesModel.AdminRole;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAdminRoles
    {
        Task<GetAllAdminRoleResponseModel> GetAllAdminRoles();
        Task<CreateAdminRoleResponseModel> CreateAdminRole(CreateAdminRoleDto newAdminRole);

        Task<UpdateAdminRoleResponseModel> UpdateAdminRole(AdminRoleDto updatedAdminRole);
        Task<GetAdminRoleByIdResponseModel> GetAdminRoleById(Guid adminRoleId);

        Task<bool> DeleteAdminRole(Guid adminRoleId);
    }
}
