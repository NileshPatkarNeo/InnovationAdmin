using Innovation_Admin.UI.Models.SysPrefGeneralBehaviour;
using Newtonsoft.Json;

namespace Innovation_Admin.UI.Models.ResponsesModel.SysPrefGeneralBehaviour
{
    public class CreateSysPrefGeneralBehaviourResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string StatusCode { get; set; }
        public CreateSysPrefGeneralBehaviourDto Data { get; set; }

    }
}
