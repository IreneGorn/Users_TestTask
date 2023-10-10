using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Users.Domain;

namespace Users.Application.Users.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
