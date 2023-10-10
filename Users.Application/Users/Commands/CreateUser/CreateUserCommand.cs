using MediatR;
using Users.Domain;

namespace Users.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }
}
