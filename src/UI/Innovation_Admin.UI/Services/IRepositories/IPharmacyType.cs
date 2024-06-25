using Innovation_Admin.UI.Models.PharmacyType;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IPharmacyType
    {
        Task<GetAllPharmacyTypeResponseModel> GetAllPharmacyTypes();
        Task<CreatePharmacyTypeResponseModel> CreatePharmacyType(PharmacyTypeDto group);

        Task<UpdatePharmacyTypeResponseModel> UpdatePharmacyType(PharmacyTypeDto updatedGroup);
        Task<GetPharmacyTypeByIdResponseModel> GetPharmacyTypeById(Guid Id);
        Task<bool> DeletePharmacyType(Guid Id);


    }
}
