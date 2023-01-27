using Application.Contracts.Specification;
using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    Task Delete(T entity, CancellationToken cancellationToken);

    //x=>x.Id
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(CancellationToken cancellationToken);

    //Specification
    Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken);
    Task<int> CountAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken);
}
//pagination => count , get all , take , skip 
//sort => name , title , price 
//order => desc , asc
//pagination => true , false