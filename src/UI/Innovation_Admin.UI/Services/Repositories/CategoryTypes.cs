using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.CategoryType;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.CategoryType;
using Innovation_Admin.UI.Models.ResponsesModel.DataSource;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class CategoryTypes : ICategoryTypes
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public CategoryTypes(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;
        public async Task<GetAllCategoryTypeResponseModel> GetAllCategoryType()
        {
            GetAllCategoryTypeResponseModel response = new GetAllCategoryTypeResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllCategoryType, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllCategoryTypeResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateCategoryTypeResponseModel> CreateCategoryType(CreateCategoryTypeDto data)
        {
            var response = new CreateCategoryTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateCategoryType,
                    HttpMethod.Post,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateCategoryTypeResponseModel>(apiResponse.data);
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

        public async Task<UpdateCategoryTypeResponseModel> UpdateCategoryType(CategoryTypeDto updatedCategoryType)
        {
            var response = new UpdateCategoryTypeResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedCategoryType);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateCategoryType.Replace("{id}", updatedCategoryType.ID.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateCategoryTypeResponseModel>(apiResponse.data);
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

        public async Task<GetCategoryTypeByIdResponseModel> GetCategoryTypeById(Guid categoryTypeId)
        {
            var response = new GetCategoryTypeByIdResponseModel();

            try
            {
                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetCategoryTypeById.Replace("{id}", categoryTypeId.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetCategoryTypeByIdResponseModel>(_oApiResponse.data);

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

        public async Task<bool> DeleteCategoryType(Guid categoryTypeId)
        {
            try
            {
                string url = URLHelper.DeleteCategoryType.Replace("{id}", categoryTypeId.ToString());
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
