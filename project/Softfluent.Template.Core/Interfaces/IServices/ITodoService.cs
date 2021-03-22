using System.Collections.Generic;
using System.Threading.Tasks;
using Softfluent.Template.Core.Dtos.Todo;

namespace Softfluent.Template.Core.Interfaces.IServices
{
    /// <summary>
    /// Provides a mechanism to manage <see cref="TodoDto"/>.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Gets all <see cref="TodoDto"/>.
        /// </summary>
        /// <returns>Collection of all <see cref="TodoDto"/>.</returns>
        Task<IEnumerable<TodoDto>> GetAllAsync();

        /// <summary>
        /// Gets <see cref="TodoDto"/> by it's ID.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns><see cref="TodoDto"/>.</returns>
        Task<TodoDto> GetByIdAsync(long id);

        /// <summary>
        /// Create new <see cref="TodoDto"/>.
        /// </summary>
        /// <param name="model">Informations.</param>
        /// <returns>Created <see cref="TodoDto"/>.</returns>
        Task<TodoDto> AddAsync(NewTodoDto model);

        /// <summary>
        /// Update <see cref="TodoDto"/>.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="model">Informations.</param>
        /// <returns>Updated <see cref="TodoDto"/>.</returns>
        Task<TodoDto> UpdateAsync(long id, UpdateTodoDto model);

        /// <summary>
        /// Remove <see cref="TodoDto"/> by it's ID.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Removed <see cref="TodoDto"/>.</returns>
        Task<TodoDto> RemoveAsync(long id);
    }
}