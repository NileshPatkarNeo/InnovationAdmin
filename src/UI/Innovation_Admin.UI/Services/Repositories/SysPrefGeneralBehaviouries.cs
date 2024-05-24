using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class SysPrefGeneralBehaviouries : ISysPrefGeneralBehaviouries
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public SysPrefGeneralBehaviouries(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
         
            _apiRepository = new APIRepository(_configuration);
        }

        public async Task<GetAllSysPrefGeneralBehaviourResponseModel> GetAllSysPrefBehaviouries()
        {
            GetAllSysPrefGeneralBehaviourResponseModel response = new GetAllSysPrefGeneralBehaviourResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllSysPrefGeneralBehaviour, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllSysPrefGeneralBehaviourResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }


        public async Task<CreateSysPrefGeneralBehaviourResponseModel> CreateSysPrefGeneralBehaviour(CreateSysPrefGeneralBehaviourDto company)
        {
            var response = new CreateSysPrefGeneralBehaviourResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(company);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreatelSysPrefGeneralBehaviour,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateSysPrefGeneralBehaviourResponseModel>(apiResponse.data);
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



        public async Task<UpdateSysPrefGeneralBehaviourResponseModel> UpdateSysPrefGeneralBehaviour(SysPrefGeneralBehaviourDto updatedCompany)
        {
            var response = new UpdateSysPrefGeneralBehaviourResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedCompany);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateSysPrefGeneralBehaviour.Replace("{id}", updatedCompany.Preference_ID.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateSysPrefGeneralBehaviourResponseModel>(apiResponse.data);
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



        public async Task<GetSysPrefGeneralBehaviourByIdResponseModel> GetPrefGeneralBehaviourById(Guid Preference_ID)
        {
            var response = new GetSysPrefGeneralBehaviourByIdResponseModel();

            try
            {

                // Make the API call to fetch the SysPrefGeneralBehaviour by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetSysPrefGeneralBehaviourById.Replace("{id}", Preference_ID.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetSysPrefGeneralBehaviourByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {
                    // If no data is returned, set IsSuccess to false and provide an appropriate message
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified Preference ID.";
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


        public async Task<bool> DeleteSysPrefGeneralBehaviour(Guid Preference_ID)
        {
            try
            {
                string url = URLHelper.DeleteSysPrefGeneralBehaviour.Replace("{id}",Preference_ID.ToString());
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
