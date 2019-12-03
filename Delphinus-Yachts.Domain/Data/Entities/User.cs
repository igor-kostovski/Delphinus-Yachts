using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Delphinus_Yachts.Domain.Data.Entities
{
    public class User : IdentityUser
    {
        public bool IsDeleted { get; set; }
    }
}
