using System.Linq;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;
using Microsoft.AspNet.Identity;

namespace Delphinus_Yachts.Domain.Services
{
    public class UserService
    {
        private readonly AppUserManager _userManager;

        public UserService(AppUserManager userManager)
        {
            _userManager = userManager;
        }

        public bool Create(LoginModel model)
        {
            var userWithSameEmail = _userManager.Users
                .FirstOrDefault(x => x.UserName == model.Email || x.Email == model.Email);
            if (userWithSameEmail != null)
                return false;

            var entity = new User
            {
                UserName = model.Email
            };
            var result = _userManager.Create(entity, model.Password);
            return result.Succeeded;
        }
    }
}
