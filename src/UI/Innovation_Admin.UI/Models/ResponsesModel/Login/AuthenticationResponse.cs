namespace Innovation_Admin.UI.Models.ResponsesModel.Login
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get ; set; }

    }
}
