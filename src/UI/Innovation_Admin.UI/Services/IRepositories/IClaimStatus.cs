using Innovation_Admin.UI.Models.ClaimStatus;
using Innovation_Admin.UI.Models.ResponsesModel.ClaimStatus;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IClaimStatus
    {
        Task<GetAllClaimStatusResponseModel> GetAllClaimStatus();

        Task<CreateClaimStatusResponseModel> CreateClaimStatus(ClaimStatusDto claim);
        Task<UpdateClaimStatusResponseModel> UpdateClaimStatus(ClaimStatusDto claim);
        Task<GetClaimStatusByIdResponseModel> GetClaimStatusById(Guid Id);

        Task<bool> DeleteClaimStatus(Guid Id);
    }
}
