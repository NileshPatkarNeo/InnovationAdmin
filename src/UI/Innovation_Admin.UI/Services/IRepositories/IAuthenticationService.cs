using Innovation_Admin.UI.Models.ResponsesModel.Login;

namespace Innovation_Admin.UI.Services.IRepositories
{
    public interface IAuthenticationService
    {
         Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

    }
}
