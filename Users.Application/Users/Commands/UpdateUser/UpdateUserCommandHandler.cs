using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Application.Common.Exceptions;
using Users.Domain;

namespace Users.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler 
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateUserCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.UserName = request.UserName;
            entity.Age = request.Age;
            entity.Email = request.Email;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
