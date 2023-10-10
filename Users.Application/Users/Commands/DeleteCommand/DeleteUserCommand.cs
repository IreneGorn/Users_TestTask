using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Users.Application.Users.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest
    {
        public Guid RoleId { get; set; }
        public Guid Id { get; set; }
    }
}
