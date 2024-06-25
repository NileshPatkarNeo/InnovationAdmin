using Innovation_Admin.UI.Models.CategoryType;
using Innovation_Admin.UI.Models.ResponsesModel.CategoryType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ICategoryTypes
    {
        Task<GetAllCategoryTypeResponseModel> GetAllCategoryType();

        Task<CreateCategoryTypeResponseModel> CreateCategoryType(CreateCategoryTypeDto data);

        Task<UpdateCategoryTypeResponseModel> UpdateCategoryType(CategoryTypeDto updatedCategoryType);
        Task<GetCategoryTypeByIdResponseModel> GetCategoryTypeById(Guid categoryTypeId);

        Task<bool> DeleteCategoryType(Guid categoryTypeId);
    }
}
