using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Common.Exceptions;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.DeleteCommand;
using Users.Tests.Common;
using Xunit;

namespace Users.Tests.Users.Commands
{
    public class DeleteUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteUserCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteUserCommand
            {
                Id = UsersContextFactory.UserIdForDelete,
                RoleId = UsersContextFactory.RoleAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Users.SingleOrDefault(user =>
                user.Id == UsersContextFactory.UserIdForDelete));
        }

        [Fact]
        public async Task DeleteUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteUserCommand
                    {
                        Id = Guid.NewGuid(),
                        RoleId = UsersContextFactory.RoleAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteUserCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteUserCommandHandler(Context);
            var createHandler = new CreateUserCommandHandler(Context);
            var userId = await createHandler.Handle(
                new CreateUserCommand
                {
                    UserName = "UserName",
                    RoleId = UsersContextFactory.RoleAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteUserCommand
                    {
                        Id = userId,
                        RoleId = UsersContextFactory.RoleBId
                    }, CancellationToken.None));
        }
    }
}
