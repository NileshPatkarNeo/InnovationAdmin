using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.BillingMethodType;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.BillingMethodType;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class BillingMethodTypes : IBillingMethodTypes
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;

        public BillingMethodTypes(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
        }


        public async Task<GetAllBillingMethodTypeResponseModel> GetAllBillingMethodType()
        {
            GetAllBillingMethodTypeResponseModel response = new GetAllBillingMethodTypeResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllBillingMethodType, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllBillingMethodTypeResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }


        public async Task<CreateBillingMethodTypeResponseModel> CreateBillingMethodType(CreateBillingMethodTypeDto billing)
        {
            var response = new CreateBillingMethodTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(billing);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateBillingMethodType,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateBillingMethodTypeResponseModel>(apiResponse.data);
                    response.IsSuccess = apiResponseObject.IsSuccess;
                    response.Data = apiResponseObject.Data;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; // Ideally, log this exception
            }

            return response;
        }

        public async Task<UpdateBillingMethodTypeResponseModel> UpdateBillingMethodType(BillingMethodTypeDto updateBillingMethodType)
        {
            var response = new UpdateBillingMethodTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updateBillingMethodType);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateBillingMethodType.Replace("{id}", updateBillingMethodType.ID.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateBillingMethodTypeResponseModel>(apiResponse.data);
                    response.IsSuccess = apiResponse.Success;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; // Ideally, log this exception
            }

            return response;
        }

        public async Task<GetBillingMethodTypeByIdResponseModel> GetBillingMethodTypeById(Guid billingMethodId)
        {
            var response = new GetBillingMethodTypeByIdResponseModel();

            try
            {
                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetBillingMethodTypeById.Replace("{id}", billingMethodId.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetBillingMethodTypeByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {
                    // If no data is returned, set IsSuccess to false and provide an appropriate message
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified datasource ID.";
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                response.IsSuccess = false;
                response.Message = ex.Message; // Log this exception
            }

            return response;
        }

        public async Task<bool> DeleteBillingMethodType(Guid billingMethodId)
        {
            try
            {
                string url = URLHelper.DeleteBillingMethodType.Replace("{id}", billingMethodId.ToString());
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
                // Log the exception
                return false;
            }
        }
    }
}
