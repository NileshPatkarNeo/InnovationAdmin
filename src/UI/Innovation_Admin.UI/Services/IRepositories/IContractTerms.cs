using Innovation_Admin.UI.Models.ContractTerms;
using Innovation_Admin.UI.Models.ResponsesModel.ContractTerm;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IContractTerms
    {

        Task<GetAllContractTermsResponseModel> GetAllContractTerms();
        Task<CreateContractTermResponseModel> CreateContractTerm(CreateContractTermDto newContractTerm);
        Task<UpdateContractTermResponseModel> UpdateContractTerm(ContractTermDto updatedContractTerm);
        Task<GetContractTermByIdResponseModel> GetContractTermById(Guid contractTermId);
        Task<bool> DeleteContractTerm(Guid contractTermId);
    }
}
