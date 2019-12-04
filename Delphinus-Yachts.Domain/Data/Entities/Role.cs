using Microsoft.AspNet.Identity.EntityFramework;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class Role : IdentityRole
    {
        public bool IsDeleted { get; set; }
    }
}
