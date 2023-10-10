using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Users.Commands.DeleteCommand
{
    internal class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(createUserCommand =>
                createUserCommand.RoleId).NotEqual(Guid.Empty);
            RuleFor(createUserCommand =>
                createUserCommand.Id).NotEqual(Guid.Empty); 
        }
    }
}
