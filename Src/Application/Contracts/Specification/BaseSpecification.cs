using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Application.Contracts.Specification;

public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    //x=>x.Title == title && x.CreateDate > DateTime.Now || &&
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDesc { get; private set; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool IsPagingEnabled { get; set; }

    public Expression<Func<T, bool>> Predicate { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> predicate)
    {
        Predicate = predicate;
    }

    protected void AddInclude(Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescByExpression)
    {
        OrderByDesc = orderByDescByExpression;
    }

    protected void ApplyPaging(int skip, int take, bool isPagingEnabled = true)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = isPagingEnabled;
    }
}