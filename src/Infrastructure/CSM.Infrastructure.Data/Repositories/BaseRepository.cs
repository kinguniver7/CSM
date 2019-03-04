using CSM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Infrastructure.Data.Repositories
{
    /// <inheritdoc />
    /// <summary>
    /// Represents the base class for repositories
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">Type of primary key</typeparam>
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary> 
        /// Returns database context for working with new entities 
        /// </summary>
        protected readonly ApplicationDbContext DbContext;

        /// <summary> 
        /// Returns datadase set for working with entity 
        /// </summary>
        protected readonly DbSet<TEntity> Entities;

        /// <summary>
        /// Constructs base repository
        /// </summary>
        /// <param name="dbContext">Database context for new entities</param>
        /// <param name="entities">Entities set for operations</param>
        protected BaseRepository(ApplicationDbContext dbContext, DbSet<TEntity> entities)
        {
            // Initialization of database context for new entities
            this.DbContext = dbContext;

            // Sets entities 
            this.Entities = entities;
        }

        /// <summary>
        /// Returns the queryable set
        /// </summary>
        /// <returns>Queryable set</returns>
        public IQueryable<TEntity> Get()
        {
            return Entities.AsQueryable();
        }

        /// <summary> 
        /// Returns all entities from the set 
        /// </summary>
        /// <returns>List of entities</returns>
        public List<TEntity> GetList()
        {
            return Entities.ToList();
        }

        /// <summary> 
        /// Returns all entities from the set (asynchronously) 
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<TEntity>> GetListAsync()
        {
            return await Entities.ToListAsync();
        }

        /// <summary> 
        /// Gets entity by id 
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity</returns>
        public TEntity Find(TKey id)
        {
            return Entities.Find(id);
        }

        /// <summary> 
        /// Gets entity by id (asynchronously) 
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <returns>Entity</returns>
        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await Entities.FindAsync(id);
        }

        /// <summary> 
        /// Adds the new entity to database 
        /// </summary>
        /// <param name="entity">Entity for adding</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        public virtual void Add(TEntity entity, bool commit = false)
        {
            if (entity != null)
            {
                // Adds entity to set
                Entities.Add(entity);

                // Saves entities to database
                if (commit)
                {
                    DbContext.SaveChanges();
                }
            }
        }

        /// <summary> 
        /// Adds the new entity to database 
        /// </summary>
        /// <param name="entity">Entity for adding</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        public async Task AddAsync(TEntity entity, bool commit = false)
        {
            if (entity != null)
            {
                // Adds entity to set
                await Entities.AddAsync(entity);

                // Saves entities to database
                if (commit)
                {
                    await DbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary> 
        /// Adds the range of entities to database 
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        public void AddRange(IEnumerable<TEntity> entities, bool commit = false)
        {
            if (entities != null && entities.Any())
            {
                // Adds entities to set
                this.Entities.AddRange(entities);

                // Saves entities to database
                if (commit)
                {
                    DbContext.SaveChanges();
                }
            }
        }

        /// <summary> 
        /// Adds the range of entities to database 
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after adding)</param>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities, bool commit = false)
        {
            if (entities != null && entities.Any())
            {
                // Adds entities to set
                await this.Entities.AddRangeAsync(entities);

                // Saves entities to database
                if (commit)
                {
                    await DbContext.SaveChangesAsync();
                }
            }
        }

        /// <summary> 
        /// Delete entity from database by id 
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        public void Delete(TKey id, bool commit = false)
        {
            TEntity entity = Find(id);
            if (entity != null)
            {
                // Removes entity from set
                Entities.Remove(entity);

                // Saves entities to database
                if (commit)
                {
                    DbContext.SaveChanges();
                }
            }
        }

        /// <summary> 
        /// Delete entity from database by id (asynchronously) 
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        public async Task DeleteAsync(TKey id, bool commit = false)
        {
            TEntity entity = await FindAsync(id);
            if (entity != null)
            {
                // Removes entity from set
                Entities.Remove(entity);

                // Saves entities to database
                if (commit)
                {
                    DbContext.SaveChanges();
                }
            }
        }

        /// <inheritdoc />
        /// <summary> 
        /// Delete entity from database 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        public void Delete(TEntity entity, bool commit = false)
        {
            if (entity == null) return;
            // Removes entity from set
            Entities.Remove(entity);

            // Saves entities to databasse
            if (commit)
            {
                DbContext.SaveChanges();
            }
        }

        /// <summary> 
        /// Deletes the range of entities from database 
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        /// <param name="commit">For saving changes (if it's true, the method SaveChanges will be called after deleting)</param>
        public void DeleteRange(IEnumerable<TEntity> entities, bool commit = false)
        {
            if (entities != null && entities.Any())
            {
                // Removes entities from set
                this.Entities.RemoveRange(entities);

                // Saves entities to database
                if (commit)
                {
                    DbContext.SaveChanges();
                }
            }
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}

