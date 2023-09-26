using Domain.Interfaces;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        //Include
        //public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        //ThenInclude V.01
        //public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> ContinuousIncludes { get; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        //ThenInclude V.02
        public List<string> ContinuousIncludes { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        //Include
        //protected void AddInclude(Expression<Func<T, object>> includeExpression)
        //{
        //    Includes.Add(includeExpression);
        //}

        //ThenInclude V.01
        //protected void AddMultipleIncludes(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        //{
        //    ContinuousIncludes.Add(includeExpression);
        //}

        //ThenInclude V.02
        protected void AddInclude(string includeString)
        {
            ContinuousIncludes.Add(includeString);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}