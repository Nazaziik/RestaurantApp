﻿using Domain.Entities.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Specification
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        //Include
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        //ThenInclude V.01
        //public static IQueryable<TEntity> GetMultipleQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        //{
        //    var query = inputQuery;

        //    if (specification.Criteria != null)
        //    {
        //        query = query.Where(specification.Criteria);
        //    }

        //    if (specification.OrderBy != null)
        //    {
        //        query = query.OrderBy(specification.OrderBy);
        //    }

        //    if (specification.OrderByDescending != null)
        //    {
        //        query = query.OrderByDescending(specification.OrderByDescending);
        //    }

        //    if (specification.IsPagingEnabled)
        //    {
        //        query = query.Skip(specification.Skip).Take(specification.Take);
        //    }

        //    query = specification.ContinuousIncludes.Aggregate(query, (current, include) => include(current));

        //    return query;
        //}

        //ThenInclude V.02
        public static IQueryable<TEntity> GetMultipleQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}