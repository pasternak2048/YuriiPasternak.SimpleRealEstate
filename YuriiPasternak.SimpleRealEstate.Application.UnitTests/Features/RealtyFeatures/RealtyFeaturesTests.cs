using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Application.Common.Models.Pagination;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Application.UnitTests.Features.Extensions;
using NUnit.Framework.Interfaces;
using System.Linq.Expressions;
using Moq.EntityFrameworkCore;

namespace YuriiPasternak.SimpleRealEstate.Application.UnitTests.Features.RealtyFeatures
{

    public class RealtyFeaturesTests
    {
        private readonly Mock<ICurrentUserInitializer> _currentUserInitializerMock;
        private readonly Mock<ISimpleRealEstateDbContext> _contextMock;
        

        public RealtyFeaturesTests()
        {
            _currentUserInitializerMock = new();
            _contextMock = new();
        }

        [Test]
        public async Task RealtyFeatures_GetRealties()
        {
            //Arrange
            var myProfile = new GetRealtiesMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var DbSetRealties = new List<Realty>() {
                new Realty()
                {
                    Id = Guid.Parse("7e071758-9c06-41fa-9d1a-61ff05d60b2a")
                },
                new Realty()
                {
                    Id= Guid.Parse("cda7c6a4-1253-408a-b748-a9661a577302")
                }
            };

            _contextMock.Setup(x => x.Realties).ReturnsDbSet(DbSetRealties);

            var handler = new GetRealtiesHandler(_contextMock.Object, _currentUserInitializerMock.Object, mapper);

            var request = new GetRealtiesRequest
            {
                UserParams = new UserParams
                {
                    PageNumber = 1,
                    PageSize = 2
                }
            };

            //Act

            var result = await handler.Handle(request, default);

            //Assert
            var expected = new List<GetRealtiesResponse>() {
                new GetRealtiesResponse()
                {
                    Id = Guid.Parse("7e071758-9c06-41fa-9d1a-61ff05d60b2a")
                },
                new GetRealtiesResponse()
                {
                    Id= Guid.Parse("cda7c6a4-1253-408a-b748-a9661a577302")
                }
            };

            Assert.AreEqual(expected[0].Id, result[0].Id);
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> items) where T : class
        {
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IAsyncEnumerable<T>>()
                .Setup(x => x.GetAsyncEnumerator(default))
                .Returns(new TestAsyncEnumerator<T>(items.GetEnumerator()));
            dbSetMock.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(items.Provider));
            dbSetMock.As<IQueryable<T>>()
                .Setup(m => m.Expression).Returns(items.Expression);
            dbSetMock.As<IQueryable<T>>()
                .Setup(m => m.ElementType).Returns(items.ElementType);
            dbSetMock.As<IQueryable<T>>()
                .Setup(m => m.GetEnumerator()).Returns(items.GetEnumerator());

            return dbSetMock;
        }
    }
}

