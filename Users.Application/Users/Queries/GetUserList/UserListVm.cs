﻿

using Users.Domain;

namespace Users.Application.Users.Queries.GetUserList
{
    public class UserListVm
    {
        public IList<UserLookupDto> Users { get; set; }
    }
}
