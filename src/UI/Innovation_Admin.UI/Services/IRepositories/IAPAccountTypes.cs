using Innovation_Admin.UI.Models.APAccountType;
using Innovation_Admin.UI.Models.ResponsesModel.APAccountType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAPAccountTypes
    {
        Task<GetAllAPAccountTypeResponseModel> GetAllAPAccountType();

        Task<CreateAPAccountTypeResponseModel> CreateAPAccountType(CreateAPAccountTypeDto accounttype);

        Task<UpdateAPAccountTypeResponseModel> UpdateAPAccountType(APAccountTypeDto updatedAPAccountType);

        Task<GetAPAccountTypeByIdResponseModel> GetAPAccountTypeById(Guid aPAccountTypeId);

        Task<bool> DeleteAPAccountType(Guid aPAccountTypeId);
    }
}
