using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Domain.Interfaces
{
    /// <summary>
    /// Represents the base interface for repositories
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">Type of primary key</typeparam>
    public interface IBaseRepository<TEntity, TKey>
    {
        /// <summary>
        /// Returns the queryable set
        /// </summary>
        /// <returns>Queryable set</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Returns all entities from the set
        /// </summary>
        /// <returns>List of entities</returns>
        List<TEntity> GetList();

        /// <summary>
        /// Returns all entities from the set (asynchronously)
        /// </summary>
        /// <returns>List of entities</returns>
        Task<List<TEntity>> GetListAsync();

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity</returns>
        TEntity Find(TKey id);

        /// <summary>
        /// Gets entity by id (asynchronously)
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity</returns>
        Task<TEntity> FindAsync(TKey id);

        /// <summary>
        /// Adds the new entity to database
        /// </summary>
        /// <param name="entity">Entity for adding</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        void Add(TEntity entity, bool commit = false);

        /// <summary>
        /// Adds the new entity to database async
        /// </summary>
        /// <param name="entity">Entity for adding</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        Task AddAsync(TEntity entity, bool commit = false);

        /// <summary>
        /// Adds the range of entities to database
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        void AddRange(IEnumerable<TEntity> entities, bool commit = false);

        /// <summary>
        /// Adds the range of entities to database async
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities, bool commit = false);

        /// <summary>
        /// Delete entity from database by id
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        void Delete(TKey id, bool commit = false);

        /// <summary>
        /// Delete entity from database by id (asynchronously)
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        Task DeleteAsync(TKey id, bool commit = false);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        void Delete(TEntity entity, bool commit = false);

        /// <summary>
        /// Deletes the range of entities from database
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        void DeleteRange(IEnumerable<TEntity> entities, bool commit = false);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
