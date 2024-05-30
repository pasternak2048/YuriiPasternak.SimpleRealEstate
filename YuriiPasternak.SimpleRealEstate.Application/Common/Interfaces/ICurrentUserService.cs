namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    //Deprecated AspNetCore.Http
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string UserRole { get; }
    }
}
