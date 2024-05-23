using Innovation_Admin.UI.Models.AdminUser;
using Innovation_Admin.UI.Models.ResponsesModel.AdminUser;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAdminUser
    {
        Task<GetAllAdminUserResponseModel> GetAllAdminUser();

        Task<CreateAdminUserResponseModel> CreateAdminUser(CreateAdminUserDto company);

        Task<UpdateAdminUserResponseModel> UpdateAdminUser(AdminUserDto updatedAdmin);
        Task<GetAdminUserByIdResponseModel> GetAdminUserById(Guid companyId);

        Task<bool> DeleteAdminUser(Guid companyId);
    }
}
