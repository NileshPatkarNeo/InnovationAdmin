using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ClaimStatus;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.ClaimStatus;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class ClaimStatus : IClaimStatus
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimStatus(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<GetAllClaimStatusResponseModel> GetAllClaimStatus()
        {
            GetAllClaimStatusResponseModel response = new GetAllClaimStatusResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllClaimStatus, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllClaimStatusResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateClaimStatusResponseModel> CreateClaimStatus(ClaimStatusDto batch)
        {
            var response = new CreateClaimStatusResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(batch);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                URLHelper.CreateClaimStatus,
                HttpMethod.Post,
                content,
                _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateClaimStatusResponseModel>(apiResponse.data);
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



        public async Task<UpdateClaimStatusResponseModel> UpdateClaimStatus(ClaimStatusDto updatedBatch)
        {
            var response = new UpdateClaimStatusResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedBatch);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                URLHelper.UpdateClaimStatus.Replace("{id}", updatedBatch.Id.ToString()),
                HttpMethod.Put,
                content,
                _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateClaimStatusResponseModel>(apiResponse.data);
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

        public async Task<GetClaimStatusByIdResponseModel> GetClaimStatusById(Guid Id)
        {
            var response = new GetClaimStatusByIdResponseModel();

            try
            {

                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetClaimStatusByID.Replace("{id}", Id.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetClaimStatusByIdResponseModel>(_oApiResponse.data);

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


        public async Task<bool> DeleteClaimStatus(Guid Id)
        {
            try
            {
                string url = URLHelper.DeleteClaimStatus.Replace("{id}", Id.ToString());
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
