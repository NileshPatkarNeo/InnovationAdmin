using Innovation_Admin.UI.Models.DoNotTakeGroup;
using Innovation_Admin.UI.Models.ResponsesModel.DoNotTakeGroup;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IDoNotTakeGroup
    {

        Task<GetAllDoNotTakeGroupResponseModel> GetAllDoNotTakeGroup();
        Task<CreateDoNotTakeGroupResponseModel> CreateDoNotTakeGroup(DoNotTakeGroupDto group);
        Task<UpdateDoNotTakeGroupResponseModel> UpdateDoNotTakeGroup(DoNotTakeGroupDto group);
        Task<GetDoNotTakeGroupByIdResponseModel> GetDoNotTakeGroupById(Guid Id);

        Task<bool> DeleteDoNotTakeGroup(Guid Id);

    }
}
