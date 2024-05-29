using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IPharmacyGroup
    {
        Task<GetAllPharmacyGroupResponseModel> GetAllPharmacyGroups();

        Task<CreatePharmacyGroupResponseModel> CreatePharmacyGroup(PharmacyGroupDto group);

        Task<UpdatePharmacyGroupResponseModel> UpdatePharmacyGroup(PharmacyGroupDto updatedGroup);
        Task<GetPharmacyGroupByIdResponseModel> GetPharmacyGroupById(Guid Id);

        Task<bool> DeletePharmacyGroup(Guid Id);

    }
}
