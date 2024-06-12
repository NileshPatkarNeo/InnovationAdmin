using Innovation_Admin.UI.Models.BillingMethodType;
using Innovation_Admin.UI.Models.ResponsesModel.BillingMethodType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IBillingMethodTypes
    {
        Task<GetAllBillingMethodTypeResponseModel> GetAllBillingMethodType();
        Task<CreateBillingMethodTypeResponseModel> CreateBillingMethodType(CreateBillingMethodTypeDto billing);

        Task<UpdateBillingMethodTypeResponseModel> UpdateBillingMethodType(BillingMethodTypeDto updateBillingMethodType);

        Task<GetBillingMethodTypeByIdResponseModel> GetBillingMethodTypeById(Guid billingMethodId);
        Task<bool> DeleteBillingMethodType(Guid billingMethodId);
    }
}
