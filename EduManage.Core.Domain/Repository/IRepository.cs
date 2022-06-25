using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduManage.Core.Domain.SeedWork;
using EduManage.Core.Domain.Specification;

namespace EduManage.Core.Domain.Repository
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IRepository<T> Config();

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T FindById(EntityId id);

        /// <summary>
        /// Finds the by identifier async
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        Task<T> FindByIdAsync(EntityId id);

        /// <summary>
        /// Finds the single by spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>T.</returns>
        T FindSingleBySpec(ISpecification<T> spec);

        /// <summary>
        /// Finds the single by spec.f
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>T.</returns>
        Task<T> FindSingleBySpecAsync(ISpecification<T> spec);

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> Find();

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> Find(ISpecification<T> spec);

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        Task<IEnumerable<T>> FindAsync(ISpecification<T> spec);

        /// <summary>
        /// Find the specified spec.
        /// </summary>
        /// <param name="spec"></param>
        /// <returns>IQueryable&lt;T&gt;</returns>
        IQueryable<T> FindAsQueryable(ISpecification<T> spec);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T Add(T entity);

        Task AddAsync(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}