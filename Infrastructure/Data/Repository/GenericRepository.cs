using Domain.Entities.Base;
using Domain.Interfaces;
using Infrastructure.Data.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetEntityWithMultipleSpecAsync(ISpecification<T> specification)
        {
            return await ApplyMultipleSpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithMultipleSpecAsync(ISpecification<T> specification)
        {
            return await ApplyMultipleSpecification(specification).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplyMultipleSpecification(specification).CountAsync();
        }

        IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        IQueryable<T> ApplyMultipleSpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetMultipleQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}