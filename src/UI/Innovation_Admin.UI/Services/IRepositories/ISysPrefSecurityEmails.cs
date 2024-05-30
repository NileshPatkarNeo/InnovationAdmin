using Innovation_Admin.UI.Models.ResponsesModel.AdminUser;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefSecurityEmail;
using Innovation_Admin.UI.Models.SysPrefSecurityEmail;
using Microsoft.AspNetCore.Mvc;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ISysPrefSecurityEmails
    {
        Task<GetAllSysPrefSecurityEmailResponseModel> GetAllSysPrefSecurityEmail();
        Task<CreateSysPrefSecurityEmailResponseModel> CreateSysPrefSecurityEmail(CreateSysPrefSecurityEmailDto email);

        Task<UpdateSysPrefSecurityEmailResponseModel> UpdateSysPrefSecurityEmail(SysPrefSecurityEmailDto updatedEmail);

        Task<GetSysPrefSecurityEmailByIdResponseModel> GetSysPrefSecurityEmailById(Guid companyId);

        Task<bool> DeleteSysPrefSecurityEmail(Guid emailId);



    }
}
