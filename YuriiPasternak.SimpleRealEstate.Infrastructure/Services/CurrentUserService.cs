using System.Security.Claims;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Services
{
    //Deprecated AspNetCore.Http

    //public class CurrentUserService : ICurrentUserService
    //{
    //    private readonly IHttpContextAccessor _httpContextAccessor;
    //    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    //    {
    //        _httpContextAccessor = httpContextAccessor;
    //    }

    //    public Guid? UserId =>
    //        Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue("Id"),
    //            out var result)
    //            ? result
    //            : default(Guid?);

    //    public string UserRole =>
    //        _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.Role);
    //}
}
