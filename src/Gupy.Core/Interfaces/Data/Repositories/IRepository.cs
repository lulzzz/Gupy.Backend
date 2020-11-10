using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gupy.Core.Common;
using Gupy.Core.Interfaces.Data.UnitOfWork;

namespace Gupy.Core.Interfaces.Data.Repositories
{
    /// <summary>
    /// A base repository that defines a common operations
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity if found, null otherwise</returns>
        TEntity Get(int id);

        /// <summary>
        /// Asynchronously Gets Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity if found, null otherwise</returns>
        ValueTask<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets All Entities
        /// </summary>
        /// <returns>List Of Entities or Empty List if none were found</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Asynchronously Gets All Entities
        /// </summary>
        /// <returns>List Of Entities or Empty List if none were found</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Finds entities that satisfy predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List Of Entities or Empty List if none were found</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously Finds entities that satisfy predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List Of Entities or Empty List if none were found</returns>
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds entity that satisfies predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Entity if found, null otherwise</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously Finds entity that satisfies predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Entity if found, null otherwise</returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds Entity to Context
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds a range of entities
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes entity from context
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes a range of entities from context
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Unit of Work
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get list of entities constrained by <see cref="Specification{T}"/>
        /// </summary>
        /// <param name="asNoTracking">Should changes made to queried objects be tracked</param>
        /// <param name="specifications"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListAsync(bool asNoTracking = true, params Specification<TEntity>[] specifications);
    }
}