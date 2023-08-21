using Domain.Entities.Base;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification);

        Task<T> GetEntityWithMultipleSpecAsync(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllWithMultipleSpecAsync(ISpecification<T> specification);
    }
}