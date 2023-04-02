using Microsoft.AspNetCore.Identity;

namespace APIBackend.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
