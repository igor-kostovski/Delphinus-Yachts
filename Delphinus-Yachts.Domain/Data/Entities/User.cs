using Microsoft.AspNet.Identity.EntityFramework;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class User : IdentityUser
    {
        public bool IsDeleted { get; set; }
    }
}
