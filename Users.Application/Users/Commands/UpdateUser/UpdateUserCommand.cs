using MediatR;
using Users.Domain;

namespace Users.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public Guid RoleId { get; set; }
    }
}
