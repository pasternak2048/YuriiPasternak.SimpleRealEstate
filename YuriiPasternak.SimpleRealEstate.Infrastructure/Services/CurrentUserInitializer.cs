using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Services
{
    public class CurrentUserInitializer : ICurrentUserInitializer
    {
        public Guid? UserId { get; set; }
        public string? UserRole { get; set; }
    }
}
