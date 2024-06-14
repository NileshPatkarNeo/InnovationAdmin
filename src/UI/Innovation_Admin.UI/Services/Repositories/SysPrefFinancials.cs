using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.SysPrefFinancial;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefFinancial;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;
using Innovation_Admin.UI.Models.ResponsesModel;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class SysPrefFinancials : ISysPrefFinancials
    {
        private readonly APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private  string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;




        public SysPrefFinancials(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration , IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<GetAllSysPrefFinancialResponseModel> GetAllSysPrefFinancials()
        {
            var response = new GetAllSysPrefFinancialResponseModel();

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllSysPrefFinancial, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllSysPrefFinancialResponseModel>(_oApiResponse.data);
                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateSysPrefFinancialResponseModel> CreateSysPrefFinancial(SysPrefFinancialDto newSysPrefFinancial)
        {
            var response = new CreateSysPrefFinancialResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(newSysPrefFinancial);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateSysPrefFinancial,
                    HttpMethod.Post,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateSysPrefFinancialResponseModel>(apiResponse.data);
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

        public async Task<UpdateSysPrefFinancialResponseModel> UpdateSysPrefFinancial(SysPrefFinancialDto updatedSysPrefFinancial)
        {
            var response = new UpdateSysPrefFinancialResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedSysPrefFinancial);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateSysPrefFinancial.Replace("{id}", updatedSysPrefFinancial.FinancialID.ToString()), 
                    HttpMethod.Put,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateSysPrefFinancialResponseModel>(apiResponse.data);
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

        public async Task<GetSysPrefFinancialByIdResponseModel> GetSysPrefFinancialById(Guid financialId)
        {
            var response = new GetSysPrefFinancialByIdResponseModel();

            try
            {
                _oApiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.GetSysPrefFinancialById.Replace("{id}", financialId.ToString()), 
                    HttpMethod.Get, 
                    null, 
                    _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetSysPrefFinancialByIdResponseModel>(_oApiResponse.data);
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified SysPrefFinancial ID.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; // Log this exception
            }

            return response;
        }

        public async Task<bool> DeleteSysPrefFinancial(Guid financialId)
        {
            try
            {
                string url = URLHelper.DeleteSysPrefFinancial.Replace("{id}", financialId.ToString());
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
