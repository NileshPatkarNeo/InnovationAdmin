using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.CorrespondenceNote
{
    public class GetAllCorrespondenceNoteResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("data")]
        public IEnumerable<Models.CorrespondenceNote.CorrespondenceNoteDto> Data { get; set; }
    }
}
