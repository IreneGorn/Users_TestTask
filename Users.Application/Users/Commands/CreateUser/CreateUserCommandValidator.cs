using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(createUserCommand =>
                createUserCommand.Age).NotEmpty().InclusiveBetween(5, 120);
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty();
        }
    }
}
