using Innovation_Admin.UI.Models.ResponsesModel;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAPIRepository
    {
        Task<Response<string>> APICommunication(string baseurl, string URL, HttpMethod invokeType, ByteArrayContent body, string token);

    }
}
