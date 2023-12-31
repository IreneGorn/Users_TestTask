﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain;

namespace Users.Application.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public Guid RoleId { get; set; }
    }
}
