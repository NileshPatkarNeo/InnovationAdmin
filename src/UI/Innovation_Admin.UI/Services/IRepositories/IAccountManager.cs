using Innovation_Admin.UI.Models.Account_Manager;
using Innovation_Admin.UI.Models.ResponsesModel.AccountManager;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAccountManager
    {
        Task<GetAllAccountManagerResponseModel> GetAllAccountManagers();
        Task<CreateAccountManagerResponseModel> CreateAccountManager(AccountManagerDto manager);
        Task<UpdateAccountManagerResponseModel> UpdateAccountManager(AccountManagerDto manager);
        Task<GetAccountManagerByIdResponseModel> GetAccountManagerById(Guid Id);
        Task<bool> DeleteAccountManager(Guid Id);

    }
}
