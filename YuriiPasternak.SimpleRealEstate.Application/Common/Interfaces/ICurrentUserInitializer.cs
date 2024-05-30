namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    public interface ICurrentUserInitializer
    {
        public Guid? UserId { get; set; }
        public string? UserRole { get; set; }
    }
}
