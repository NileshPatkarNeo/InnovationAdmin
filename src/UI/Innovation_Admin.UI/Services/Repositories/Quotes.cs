using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.Quote;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.Quote;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class Quotes : IQuotes
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Quotes(IOptions<ApiBaseUrl> apiBaseUrl , IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;
        public async Task<GetAllQuotesResponseModel> GetAllQuotes()
        {
            var response = new GetAllQuotesResponseModel();
            _apiRepository = new APIRepository(_configuration);
            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllQuotes, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllQuotesResponseModel>(_oApiResponse.data);
                response.IsSuccess = true;
            }
            return response;
        }

        public async Task<CreateQuoteResponseModel> CreateQuote(CreateQuoteDto newQuote)
        {
            var response = new CreateQuoteResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(newQuote);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();
                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateQuote,
                    HttpMethod.Post,
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateQuoteResponseModel>(apiResponse.data);
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

        public async Task<UpdateQuoteResponseModel> UpdateQuote(QuoteDto updatedQuote)
        {
            var response = new UpdateQuoteResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedQuote);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateQuote.Replace("{id}", updatedQuote.ID.ToString()), // Define the correct URL with ID
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateQuoteResponseModel>(apiResponse.data);
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

        public async Task<GetQuoteByIdResponseModel> GetQuoteById(Guid quoteId)
        {
            var response = new GetQuoteByIdResponseModel();

            try
            {
                // Make the API call to fetch the Quote by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetQuoteById.Replace("{id}", quoteId.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetQuoteByIdResponseModel>(_oApiResponse.data);
                    response.IsSuccess = true;
                }
                else
                {
                    // If no data is returned, set IsSuccess to false and provide an appropriate message
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified Quote ID.";
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

        public async Task<bool> DeleteQuote(Guid quoteId)
        {
            try
            {
                string url = URLHelper.DeleteQuote.Replace("{id}", quoteId.ToString());
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
