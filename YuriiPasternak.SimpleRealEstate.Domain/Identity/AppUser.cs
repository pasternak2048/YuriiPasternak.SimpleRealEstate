using Microsoft.AspNetCore.Identity;

namespace YuriiPasternak.SimpleRealEstate.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
