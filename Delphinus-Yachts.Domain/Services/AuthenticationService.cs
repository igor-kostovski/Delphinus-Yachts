using Delphinus_Yachts.Domain.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Delphinus_Yachts.Domain.Services
{
    public class AuthenticationService
    {
        private readonly AppSignInManager _signInManager;

        public AuthenticationService(AppSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public SignInStatus SignIn(LoginModel model) =>
            _signInManager.PasswordSignIn(model.Email, model.Password, model.RememberMe, shouldLockout: false);

        public void SignOut() => _signInManager.AuthenticationManager.SignOut();
    }
}
