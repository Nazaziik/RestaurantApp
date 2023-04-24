﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpecAsync(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification);
    }
}