using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> ContinuousIncludes { get; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddMultipleIncludes(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        {
            ContinuousIncludes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}