using Delphinus_Yachts.Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Delphinus_Yachts.Domain
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store) { }
    }

    public class AppSignInManager : SignInManager<User, string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }
    }
}