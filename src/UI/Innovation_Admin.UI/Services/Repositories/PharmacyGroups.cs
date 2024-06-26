using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.PharmacyGroup;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class PharmacyGroups : IPharmacyGroup
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PharmacyGroups(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;
        public async Task<GetAllPharmacyGroupResponseModel> GetAllPharmacyGroups()
        {
            GetAllPharmacyGroupResponseModel response = new GetAllPharmacyGroupResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllPharmacyGroup, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllPharmacyGroupResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }


        public async Task<CreatePharmacyGroupResponseModel> CreatePharmacyGroup(PharmacyGroupDto group)
        {
            var response = new CreatePharmacyGroupResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(group);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();
                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreatePharmacyGroup,
                    HttpMethod.Post,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreatePharmacyGroupResponseModel>(apiResponse.data);
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



        public async Task<UpdatePharmacyGroupResponseModel> UpdatePharmacyGroup(PharmacyGroupDto updatedGroup)
        {
            var response = new UpdatePharmacyGroupResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedGroup);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdatePharmacyGroup.Replace("{id}", updatedGroup.Id.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                   _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdatePharmacyGroupResponseModel>(apiResponse.data);
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

        public async Task<GetPharmacyGroupByIdResponseModel> GetPharmacyGroupById(Guid Id)
        {
            var response = new GetPharmacyGroupByIdResponseModel();

            try
            {

                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetPharmacyGroupById.Replace("{id}", Id.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetPharmacyGroupByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {

                    response.IsSuccess = false;
                    response.Message = "No data found for the specified  Id";
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


        public async Task<bool> DeletePharmacyGroup(Guid Id)
        {
            try
            {
                string url = URLHelper.DeletePharmacyGroup.Replace("{id}", Id.ToString());
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
