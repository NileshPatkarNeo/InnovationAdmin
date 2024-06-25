using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.APAccountType;
using Innovation_Admin.UI.Models.DataSource;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.APAccountType;
using Innovation_Admin.UI.Models.ResponsesModel.DataSource;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class APAccountTypes : IAPAccountTypes
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public APAccountTypes(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<GetAllAPAccountTypeResponseModel> GetAllAPAccountType()
        {
            GetAllAPAccountTypeResponseModel response = new GetAllAPAccountTypeResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllAPAccountType, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllAPAccountTypeResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateAPAccountTypeResponseModel> CreateAPAccountType(CreateAPAccountTypeDto accounttype)
        {
            var response = new CreateAPAccountTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(accounttype);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateAPAccountType,
                    HttpMethod.Post,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateAPAccountTypeResponseModel>(apiResponse.data);
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

        public async Task<UpdateAPAccountTypeResponseModel> UpdateAPAccountType(APAccountTypeDto updatedAPAccountType)
        {
            var response = new UpdateAPAccountTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedAPAccountType);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateAPAccountType.Replace("{id}", updatedAPAccountType.ID.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateAPAccountTypeResponseModel>(apiResponse.data);
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

        public async Task<GetAPAccountTypeByIdResponseModel> GetAPAccountTypeById(Guid aPAccountTypeId)
        {
            var response = new GetAPAccountTypeByIdResponseModel();

            try
            {
                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAPAccountTypeById.Replace("{id}", aPAccountTypeId.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetAPAccountTypeByIdResponseModel>(_oApiResponse.data);

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

        public async Task<bool> DeleteAPAccountType(Guid aPAccountTypeId)
        {
            try
            {
                string url = URLHelper.DeleteAPAccountType.Replace("{id}", aPAccountTypeId.ToString());
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
