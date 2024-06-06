using Innovation_Admin.UI.Models.ReceiptBatchSource;
using Innovation_Admin.UI.Models.ResponsesModel.ReceiptBatchSource;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IReceiptBatchSource
    {
        Task<GetAllReceiptBatchSourceResponseModel> GetAllReceiptBatchSource();

        Task<CreateReceiptBatchSourceResponseModel> CreateReceiptBatchSource(ReceiptBatchSourceDto batch);
        Task<UpdateReceiptBatchSourceResponseModel> UpdateReceiptBatchSource(ReceiptBatchSourceDto batch);
        Task<GetReceiptBatchSourceByIdResponseModel> GetReceiptBatchSourceById(Guid Id);

        Task<bool> DeleteReceiptBatchSource(Guid Id);

    }
}
