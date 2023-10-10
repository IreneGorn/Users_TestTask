using Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Users.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
