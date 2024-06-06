using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.RemittanceType;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.RemittanceType;
using Innovation_Admin.UI.Services.Repositories;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IRemittanceType
    {
        Task<GetAllRemittanceTypeResponseModel> GetAllRemittanceTypes();

        Task<CreateRemittanceTypeResponseModel> CreateRemittanceType(RemittanceTypeDto type);
        Task<UpdateRemittanceTypeResponseModel> UpdateRemittanceType(RemittanceTypeDto updatedType);
        Task<GetRemittanceTypeByIdResponseModel> GetRemittanceTypeById(Guid Id);
        Task<bool> DeleteRemittanceType(Guid Id);
    }
}
