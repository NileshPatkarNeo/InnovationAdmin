using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefFinancial;
using Innovation_Admin.UI.Models.SysPrefFinancial;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ISysPrefFinancials
    {

        Task<GetAllSysPrefFinancialResponseModel> GetAllSysPrefFinancials();
        Task<CreateSysPrefFinancialResponseModel> CreateSysPrefFinancial(SysPrefFinancialDto newSysPrefFinancial);
        Task<UpdateSysPrefFinancialResponseModel> UpdateSysPrefFinancial(SysPrefFinancialDto updatedSysPrefFinancial);
        Task<GetSysPrefFinancialByIdResponseModel> GetSysPrefFinancialById(Guid financialId);
        Task<bool> DeleteSysPrefFinancial(Guid financialId);
    }
}
