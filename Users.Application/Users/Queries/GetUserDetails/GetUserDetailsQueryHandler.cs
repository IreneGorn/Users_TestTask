using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Interfaces;
using Users.Application.Common.Exceptions;
using Users.Domain;

namespace Users.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IUsersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUsersDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if (entity == null || entity.RoleId != request.RoleId) 
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
        
    }
}
