using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UnitOWork : IUnitOWork
{
    private readonly ApplicationDbContext _context;

    public UnitOWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public DbContext Context => _context;

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        return new GenericRepository<T>(_context);
    }
}