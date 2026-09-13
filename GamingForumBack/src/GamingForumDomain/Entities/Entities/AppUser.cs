
using Microsoft.AspNetCore.Identity;


namespace GamingForumDomain.Entities.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
