using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Users.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler 
        : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IUsersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUsersDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {
            var usersQuery = await _dbContext.Users
                .Where(user => user.RoleId == request.RoleId)
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = usersQuery };
        }
    }
}
