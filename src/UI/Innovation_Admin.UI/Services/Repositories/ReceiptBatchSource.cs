using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ReceiptBatchSource;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.ReceiptBatchSource;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class ReceiptBatchSource : IReceiptBatchSource
    {
        private APIRepository _apiRepository;

    private Response<string> _oApiResponse;
    private string _sToken = string.Empty;
    private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
    private readonly IConfiguration _configuration;
    public ReceiptBatchSource(IOptions<ApiBaseUrl> apiBaseUrl)
    {
        _apiBaseUrl = apiBaseUrl;
        _apiRepository = new APIRepository(_configuration);
    }

    public async Task<GetAllReceiptBatchSourceResponseModel> GetAllReceiptBatchSource()
    {
            GetAllReceiptBatchSourceResponseModel response = new GetAllReceiptBatchSourceResponseModel();

        _apiRepository = new APIRepository(_configuration);

        _oApiResponse = new Response<string>();
        byte[] content = Array.Empty<byte>();
        var bytes = new ByteArrayContent(content);
        _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllReceiptBatchSource, HttpMethod.Get, bytes, _sToken);
        if (_oApiResponse.data != null)
        {
            response = JsonConvert.DeserializeObject<GetAllReceiptBatchSourceResponseModel>(_oApiResponse.data);

            response.IsSuccess = true;
        }

        return response;
    }

    public async Task<CreateReceiptBatchSourceResponseModel> CreateReceiptBatchSource(ReceiptBatchSourceDto batch)
    {
        var response = new CreateReceiptBatchSourceResponseModel();

        try
        {
            var jsonContent = JsonConvert.SerializeObject(batch);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiResponse = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                URLHelper.CreateReceiptBatchSource,
                HttpMethod.Post,
                content,
                string.Empty);

            if (!string.IsNullOrEmpty(apiResponse.data))
            {
                var apiResponseObject = JsonConvert.DeserializeObject<CreateReceiptBatchSourceResponseModel>(apiResponse.data);
                response.IsSuccess = apiResponseObject.IsSuccess;
                response.Data = apiResponseObject.Data;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message; 
        }

        return response;
    }



    public async Task<UpdateReceiptBatchSourceResponseModel> UpdateReceiptBatchSource(ReceiptBatchSourceDto updatedBatch)
    {
        var response = new UpdateReceiptBatchSourceResponseModel();

        try
        {
            var jsonContent = JsonConvert.SerializeObject(updatedBatch);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiResponse = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                URLHelper.UpdateReceiptBatchSource.Replace("{id}", updatedBatch.Id.ToString()), 
                HttpMethod.Put, 
                content,
                string.Empty);

            if (!string.IsNullOrEmpty(apiResponse.data))
            {
                response = JsonConvert.DeserializeObject<UpdateReceiptBatchSourceResponseModel>(apiResponse.data);
                response.IsSuccess = apiResponse.Success;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message; 
        }

        return response;
    }

    public async Task<GetReceiptBatchSourceByIdResponseModel> GetReceiptBatchSourceById(Guid Id)
    {
        var response = new GetReceiptBatchSourceByIdResponseModel();

        try
        {

            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetReceiptBatchSourceById.Replace("{id}", Id.ToString()), HttpMethod.Get, null, _sToken);

            if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
            {

                response = JsonConvert.DeserializeObject<GetReceiptBatchSourceByIdResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }
            else
            {

                response.IsSuccess = false;
                response.Message = "No data found for the specified Receipt Batch ID.";
            }
        }
        catch (Exception ex)
        {
          
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }


    public async Task<bool> DeleteReceiptBatchSource(Guid Id)
    {
        try
        {
            string url = URLHelper.DeleteReceiptBatchSource.Replace("{id}", Id.ToString());
            var response = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                url,
                HttpMethod.Delete,
                new ByteArrayContent(Array.Empty<byte>()),
                string.Empty
            );

            return response != null && response.Success;
        }
        catch (Exception ex)
        {
            
            return false;
        }
    }



}
}
