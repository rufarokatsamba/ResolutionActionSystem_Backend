
using Microsoft.AspNetCore.Identity;

namespace ResolutionActionSystem.Identity.Models
{
    public class SystemUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
