using Innovation_Admin.UI.Models.ResponsesModel.CategoryType;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ICategoryTypes
    {
        Task<GetAllCategoryTypeResponseModel> GetAllCategoryType();
    }
}
