using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Users.Queries.GetUserDetails;
using Users.Persistence;
using Users.Tests.Common;
using Xunit;

namespace Users.Tests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserDetailsQueryHandlerTests
    {
        private readonly UsersDbContext Context;
        private readonly IMapper Mapper;

        public GetUserDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetUserDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetUserDetailsQuery
                {
                    RoleId = UsersContextFactory.RoleBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<UserDetailsVm>();
            result.UserName.ShouldBe("Name2");
            result.Age.ShouldBe(20);
        }
    }
}
