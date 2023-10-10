using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Users.Commands.CreateUser;
using Users.Tests.Common;
using Xunit;

namespace Users.Tests.Users.Commands
{
    public class CreateUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateUserCommandHandler(Context);
            var userName = "user name";
            var userAge = 30;
            var userEmail = "user email";

            // Act
            var userId = await handler.Handle(
                new CreateUserCommand
                {
                    UserName = userName,
                    Age = userAge,
                    Email = userEmail,
                    RoleId = UsersContextFactory.RoleAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == userId && 
                    user.UserName == userName &&
                    user.Age == userAge &&
                    user.Email == userEmail));
        }
    }
}
