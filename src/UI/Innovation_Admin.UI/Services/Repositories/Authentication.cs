using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.Login;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

//namespace Innovation_Admin.UI.Services.Repositories
//{
//    public class Authentication : IAuthenticationService
//    {
//        private APIRepository _apiRepository;

//        private Response<string> _oApiResponse;
//        private string _sToken = string.Empty;
//        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
//        private readonly IConfiguration _configuration;

//        public Authentication(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
//        {
//            _apiBaseUrl = apiBaseUrl;
//            _configuration = configuration;
//            _apiRepository = new APIRepository(_configuration);
//        }
//        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
//        {
//            var response = new AuthenticationResponse();

//            try
//            {
//                var jsonContent = JsonConvert.SerializeObject(request);
//                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//                var apiResponse = await _apiRepository.APICommunication(
//                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
//                    URLHelper.Authenticate,
//                    HttpMethod.Post,
//                    content,
//                    string.Empty);

//                if (!string.IsNullOrEmpty(apiResponse.data))
//                {
//                    response = JsonConvert.DeserializeObject<AuthenticationResponse>(apiResponse.data);
//                    response.IsAuthenticated = apiResponse.Success;
//                }
//            }
//            catch (Exception ex)
//            {
//                response.IsAuthenticated = false;
//                response.Message = ex.Message; // Ideally, log this exception
//            }

//            return response;
//        }





//    }
//}
using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class Authentication : IAuthenticationService
    {
        private readonly APIRepository _apiRepository;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;

        public Authentication(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.Authenticate,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<AuthenticationResponse>(apiResponse.data);
                    response.IsAuthenticated = apiResponse.Success;
                }
            }
            catch (Exception ex)
            {
                response.IsAuthenticated = false;
                response.Message = ex.Message; // Ideally, log this exception
            }

            return response;
        }
    }
}
