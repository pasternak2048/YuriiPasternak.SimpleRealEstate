namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string UserRole { get; }
    }
}
