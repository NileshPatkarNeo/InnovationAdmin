using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.SysPrefCompany;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface ISysPrefCompanies
    {
        Task<GetAllSysPrefCompanyResponseModel> GetAllSysPrefCompanies();

        Task<CreateSysPrefCompanyResponseModel> CreateSysPrefCompany(SysPrefCompanyDto company);
        Task<UpdateSysPrefCompanyResponseModel> UpdateSysPrefCompany(SysPrefCompanyDto updatedCompany);
        Task<GetSysPrefCompanyByIdResponseModel> GetSysPrefCompanyById(Guid companyId);

        Task<bool> DeleteSysPrefCompany(Guid companyId);

    }
}
