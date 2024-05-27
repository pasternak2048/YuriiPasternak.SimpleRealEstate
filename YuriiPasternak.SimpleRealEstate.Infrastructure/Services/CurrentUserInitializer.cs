using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Services
{
    public class CurrentUserInitializer : ICurrentUserInitializer
    {
        public string? UserId { get; set; }
        public string? UserRole { get; set; }
    }
}
