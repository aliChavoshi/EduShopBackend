using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Application.Contracts.Specification;

public interface ISpecification<T> where T : BaseEntity
{
    //x=>x.id
    Expression<Func<T, bool>> Predicate { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDesc { get; }
    //pagination
    public int Take { get; }
    public int Skip { get; }
    public bool IsPagingEnabled { get; }
}