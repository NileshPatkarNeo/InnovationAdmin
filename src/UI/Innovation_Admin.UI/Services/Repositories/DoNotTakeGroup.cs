using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.DoNotTakeGroup;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.DoNotTakeGroup;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class DoNotTakeGroup : IDoNotTakeGroup
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DoNotTakeGroup(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;
        public async Task<GetAllDoNotTakeGroupResponseModel> GetAllDoNotTakeGroup()
        {
            GetAllDoNotTakeGroupResponseModel response = new GetAllDoNotTakeGroupResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllDoNotTakeGroup, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllDoNotTakeGroupResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }

        public async Task<CreateDoNotTakeGroupResponseModel> CreateDoNotTakeGroup(DoNotTakeGroupDto Group)
        {
            var response = new CreateDoNotTakeGroupResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(Group);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateDoNotTakeGroup,
                    HttpMethod.Post,
                    content,
              _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateDoNotTakeGroupResponseModel>(apiResponse.data);
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



        public async Task<UpdateDoNotTakeGroupResponseModel> UpdateDoNotTakeGroup(DoNotTakeGroupDto updatedgroup)
        {
            var response = new UpdateDoNotTakeGroupResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedgroup);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateDoNotTakeGroup,
                    HttpMethod.Put,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateDoNotTakeGroupResponseModel>(apiResponse.data);
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

        public async Task<GetDoNotTakeGroupByIdResponseModel> GetDoNotTakeGroupById(Guid Id)
        {
            var response = new GetDoNotTakeGroupByIdResponseModel();

            try
            {

                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetDoNotTakeGroupByID.Replace("{id}", Id.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetDoNotTakeGroupByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {

                    response.IsSuccess = false;
                    response.Message = "No data found for the specified Receipt Group ID.";
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<bool> DeleteDoNotTakeGroup(Guid Id)
        {
            try
            {
                string url = URLHelper.DeleteDoNotTakeGroup.Replace("{id}", Id.ToString());
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
