using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ICurrentUserInitializer _currentUserInitializer;

        public TestController(ICurrentUserInitializer currentUserInitializer)
        {
            _currentUserInitializer = currentUserInitializer;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> GetCurrentUser()
        {
            var result = _currentUserInitializer.UserId?.ToString();

            return result;
        }
    }
}
