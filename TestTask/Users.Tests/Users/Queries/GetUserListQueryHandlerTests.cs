﻿using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Users.Queries.GetUserList;
using Users.Persistence;
using Users.Tests.Common;
using Shouldly;
using Xunit;

namespace Users.Tests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserListQueryHandlerTests
    {
        private readonly UsersDbContext Context;
        private readonly IMapper Mapper;

        public GetUserListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetUserListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetUserListQuery
                {
                    RoleId = UsersContextFactory.RoleBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<UserListVm>();
            result.Users.Count.ShouldBe(2);
        }
    }
}
