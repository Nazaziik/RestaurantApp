using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        //Include
        List<Expression<Func<T, object>>> Includes { get; }

        //ThenInclude V.01
        //List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> ContinuousIncludes { get; }

        //ThenInclude V.02
        List<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}