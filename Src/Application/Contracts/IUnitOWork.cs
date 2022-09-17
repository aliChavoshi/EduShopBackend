using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IUnitOWork
{
    DbContext Context { get; }
    Task<int> Save(CancellationToken cancellationToken);
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
}