using System.Collections.Generic;
using System.Threading.Tasks;
using $safeprojectname$.Entities;

namespace $safeprojectname$.Interfaces.IRepositories
{
    /// <summary>
    /// Provides data by <see cref="TodoEntity"/> from database.
    /// </summary>
    public interface ITodoRepository
    {
        /// <summary>
        /// Get a collection <see cref="TodoEntity"/> from the database.
        /// </summary>
        /// <returns>Collection of <see cref="TodoEntity"/> of the database.</returns>
        public Task<IEnumerable<TodoEntity>> GetAllAsync();

        /// <summary>
        /// Get <see cref="TodoEntity"/> from the database by it's ID
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns><see cref="TodoEntity"/>.</returns>
        public Task<TodoEntity> GetByIdAsync(long id);

        /// <summary>
        /// Create new <see cref="TodoEntity"/> in database.
        /// </summary>
        /// <param name="entity">Informations.</param>
        /// <returns>Created <see cref="TodoEntity"/>.</returns>
        public Task<TodoEntity> AddAsync(TodoEntity entity);

        /// <summary>
        /// Update <see cref="TodoEntity"/> in database.
        /// </summary>
        /// <param name="entity">Informations to update.</param>
        /// <returns>Updated <see cref="TodoEntity"/>.</returns>
        public Task<TodoEntity> UpdateAsync(TodoEntity entity);

        /// <summary>
        /// Remove <see cref="TodoEntity"/> from the database by it's ID.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Removed <see cref="TodoEntity"/>.</returns>
        public Task<TodoEntity> RemoveAsync(long id);
    }
}