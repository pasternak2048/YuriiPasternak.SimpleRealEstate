namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    public interface ICurrentUserInitializer
    {
        public string? UserId { get; set; }
        public string? UserRole { get; set; }
    }
}
