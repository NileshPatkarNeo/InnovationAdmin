using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.CorrespondenceNote;
using Innovation_Admin.UI.Models.DataSource;
using Innovation_Admin.UI.Models.RemittanceType;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.CorrespondenceNote;
using Innovation_Admin.UI.Models.ResponsesModel.DataSource;
using Innovation_Admin.UI.Models.ResponsesModel.RemittanceType;
using Innovation_Admin.UI.Models.ResponsesModel.SysPrefCompany;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Text;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class CorrespondenceNotes : ICorrespondenceNote
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
            
        public CorrespondenceNotes(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(_configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<GetAllCorrespondenceNoteResponseModel> GetAllCorrespondenceNotes()
        {
            GetAllCorrespondenceNoteResponseModel response = new GetAllCorrespondenceNoteResponseModel();

            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllCorrespondenceNote, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllCorrespondenceNoteResponseModel>(_oApiResponse.data);

                response.IsSuccess = true;
            }

            return response;
        }


        public async Task<CreateCorrespondenceNoteResponseModel> CreateCorrespondenceNote(CreateCorrespondenceNoteDto notemodel)
        {
            var response = new CreateCorrespondenceNoteResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(notemodel);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateCorrespondenceNote,
                    HttpMethod.Post,
                    content,
                   _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateCorrespondenceNoteResponseModel>(apiResponse.data);
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


        public async Task<UpdateCorrespondenceNoteResponseModel> UpdateCorrespondenceNote(CorrespondenceNoteDto updatedNote)
        {
            var response = new UpdateCorrespondenceNoteResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedNote);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                _sToken = Session?.GetString("Token")?.ToString();

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateCorrespondenceNote.Replace("{id}", updatedNote.Id.ToString()), // Define the 
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                   _sToken);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateCorrespondenceNoteResponseModel>(apiResponse.data);
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

        public async Task<GetAllCorrespondenceNoteByIdResponseModel> GetCorrespondenceNoteById(Guid Id)
        {
            var response = new GetAllCorrespondenceNoteByIdResponseModel();

            try
            {

                // Make the API call to fetch the SysPrefCompany by its ID
                _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetCorrespondenceNoteById.Replace("{id}", Id.ToString()), HttpMethod.Get, null, _sToken);

                if (_oApiResponse != null && !string.IsNullOrEmpty(_oApiResponse.data))
                {

                    response = JsonConvert.DeserializeObject<GetAllCorrespondenceNoteByIdResponseModel>(_oApiResponse.data);

                    response.IsSuccess = true;
                }
                else
                {

                    response.IsSuccess = false;
                    response.Message = "No data found for the specified company ID.";
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


        public async Task<bool> DeleteCorrespondenceNote(Guid correspondnoteId)
        {
            try
            {
                string url = URLHelper.DeleteCorrespondenceNote.Replace("{id}", correspondnoteId.ToString());
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
