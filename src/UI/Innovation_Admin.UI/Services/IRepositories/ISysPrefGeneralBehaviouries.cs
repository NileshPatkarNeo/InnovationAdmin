using Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ISysPrefGeneralBehaviouries
    {
        Task<GetAllSysPrefGeneralBehaviourResponseModel> GetAllSysPrefBehaviouries();


       Task<CreateSysPrefGeneralBehaviourResponseModel> CreateSysPrefGeneralBehaviour(CreateSysPrefGeneralBehaviourDto CreateSysPrefGeneralBehaviour);

        Task<UpdateSysPrefGeneralBehaviourResponseModel> UpdateSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany);
        Task<GetSysPrefGeneralBehaviourByIdResponseModel> GetPrefGeneralBehaviourById(Guid Preference_ID);

        Task<bool> DeleteSysPrefGeneralBehaviour(Guid Preference_ID);


    }

}

