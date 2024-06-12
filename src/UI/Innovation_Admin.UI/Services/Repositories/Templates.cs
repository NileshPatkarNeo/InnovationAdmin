using Innovation_Admin.UI.Helper;
using Innovation_Admin.UI.Models.ResponsesModel;
using Innovation_Admin.UI.Models.ResponsesModel.Template;
using Innovation_Admin.UI.Models.Template;
using Innovation_Admin.UI.Services.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Innovation_Admin.UI.Helper.APIBaseUrl;

namespace Innovation_Admin.UI.Services.Repositories
{
    public class Templates : ITemplates
    {
        private readonly APIRepository _apiRepository;
        private readonly string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;

        public Templates(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _apiRepository = new APIRepository(configuration);
        }

        public async Task<GetAllTemplatesResponseModel> GetAllTemplates()
        {
            var response = new GetAllTemplatesResponseModel();
            var _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.InnvoationAdminApiBaseUrl, URLHelper.GetAllTemplates, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<GetAllTemplatesResponseModel>(_oApiResponse.data);
                response.IsSuccess = true;
            }
            return response;
        }

        public async Task<CreateTemplateResponseModel> CreateTemplate(CreateTemplateDto newTemplate)
        {
            var response = new CreateTemplateResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(newTemplate);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.CreateTemplate,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    var apiResponseObject = JsonConvert.DeserializeObject<CreateTemplateResponseModel>(apiResponse.data);
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

        public async Task<UpdateTemplateResponseModel> UpdateTemplate(TemplateDto updatedTemplate)
        {
            var response = new UpdateTemplateResponseModel();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(updatedTemplate);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.UpdateTemplate.Replace("{id}", updatedTemplate.ID.ToString()), // Define the correct URL with ID
                    HttpMethod.Put, // Use PUT method for updates
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UpdateTemplateResponseModel>(apiResponse.data);
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




        public async Task<GetTemplateByIdResponseModel> GetTemplateById(Guid templateId)
        {
            var response = new GetTemplateByIdResponseModel();

            try
            {
                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.InnvoationAdminApiBaseUrl,
                    URLHelper.GetTemplateById.Replace("{id}", templateId.ToString()),
                    HttpMethod.Get,
                    null,
                    _sToken);

                if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<GetTemplateByIdResponseModel>(apiResponse.data);
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No data found for the specified Template ID.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; // Ideally, log this exception
            }

            return response;
        }

        public async Task<bool> DeleteTemplate(Guid templateId)
        {
            try
            {
                string url = URLHelper.DeleteTemplate.Replace("{id}", templateId.ToString());
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

        private static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            try
            {
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                {
                    Name = "PdfTemplateFile",
                    FileName = "\"" + fileName + "\""
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                return fileContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
