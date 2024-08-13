using MediatR;
using Moq;
using YuriiPasternak.SimpleRealEstate.Application.Common.Models.Pagination;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties;
using YuriiPasternak.SimpleRealEstate.WebAPI.Controllers;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.UnitTests.Controllers
{
    public class RealtyControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private Mock<RealtyController> _mockRealtyController;
        public RealtyControllerTests()
        {
            _mockMediator = new();
            _mockRealtyController = new();
        }

        [Test]
        public async Task RealtyController_GetRealties()
        {
            var request = new GetRealtiesRequest
            {
                UserParams = new UserParams
                {
                    PageNumber = 1,
                    PageSize = 2
                }
            };

            var realtiesResponse = new List<GetRealtiesResponse>() {
                new GetRealtiesResponse()
                {
                    Id = Guid.Parse("7e071758-9c06-41fa-9d1a-61ff05d60b2a")
                },
                new GetRealtiesResponse()
                {
                    Id= Guid.Parse("cda7c6a4-1253-408a-b748-a9661a577302")
                }
            }.AsQueryable();

            var expected = new PagedList<GetRealtiesResponse>(realtiesResponse, 2, 1, 2);

            var result = await _mockRealtyController.Object.GetRealties(request, default);

            Assert.AreEqual(expected, result.Value);
        }
    }
}
