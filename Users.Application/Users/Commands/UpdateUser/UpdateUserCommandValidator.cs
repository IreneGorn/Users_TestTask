using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Users.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(createUserCommand =>
                createUserCommand.Age).NotEmpty().InclusiveBetween(5, 120);
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty();
            RuleFor(createUserCommand =>
                createUserCommand.RoleId).NotEqual(Guid.Empty);
            RuleFor(createUserCommand =>
                createUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
