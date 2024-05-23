using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.AdminRole;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.AdminRole;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class AdminRoles : IAdminRoles
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public AdminRoles(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);

        }

        public async Task<GetAllAdminRoleResponseModel> GetAllAdminRoles()
        {
            GetAllAdminRoleResponseModel response = new GetAllAdminRoleResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllAdminRole, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllAdminRoleResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateAdminRoleResponseModel> CreateAdminRole(CreateAdminRoleDto newAdminRole)
        {
            var response = new CreateAdminRoleResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(newAdminRole);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateAdminRole,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateAdminRoleResponseModel>(apiResponse.data);
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


        public async Task<UpdateAdminRoleResponseModel> UpdateAdminRole(AdminRoleDto updatedAdminRole)
        {
            var response = new UpdateAdminRoleResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedAdminRole);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateAdminRole.Replace("{id}", updatedAdminRole.Role_ID.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateAdminRoleResponseModel>(apiResponse.data);
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

        public async Task<GetAdminRoleByIdResponseModel> GetAdminRoleById(Guid updatedAdminRole)
        {
            var response = new GetAdminRoleByIdResponseModel();

            try
            {

                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAdminRoleById.Replace("{id}", updatedAdminRole.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetAdminRoleByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {
                    // If no data is returned, set IsSuccess to false and provide an appropriate message
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified AdminRole ID.";
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

        public async Task<bool> DeleteAdminRole(Guid adminRoleId)
        {
            try
            {
                string url = URLHelper.DeleteAdminRole.Replace("{id}", adminRoleId.ToString());
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
