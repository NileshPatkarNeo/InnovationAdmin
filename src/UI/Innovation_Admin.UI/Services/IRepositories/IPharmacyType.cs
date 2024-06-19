using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IPharmacyType
    {
        Task<GetAllPharmacyTypeResponseModel> GetAllPharmacyTypes();
    }
}
