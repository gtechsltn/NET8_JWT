using JwtExamples.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtExamples.Business.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}