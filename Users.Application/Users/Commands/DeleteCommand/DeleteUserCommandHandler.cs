using MediatR;
using Users.Application.Interfaces;
using Users.Application.Common.Exceptions;
using Users.Domain;

namespace Users.Application.Users.Commands.DeleteCommand
{
    public class DeleteUserCommandHandler :
        IRequestHandler<DeleteUserCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteUserCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null) 
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
