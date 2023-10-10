using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Users.Queries.GetUserDetails;

namespace Users.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserListQueryValidator()
        {
            RuleFor(user => user.Id).NotEqual(Guid.Empty);
            RuleFor(user => user.RoleId).NotEqual(Guid.Empty);
        }
    }
}
