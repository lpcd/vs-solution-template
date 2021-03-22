using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softfluent.Template.Core.Dtos.Todo;
using Softfluent.Template.Core.Interfaces.IServices;

namespace Softfluent.Template.API.Controllers
{
    /// <summary>
    /// "Todo" endpoints.
    /// </summary>
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _service;

        /// <summary>
        /// Create new <see cref="TodoController"/> instance.
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="service"><see cref="ITodoService"/></param>
        public TodoController(ILogger<TodoController> logger,
            ITodoService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Gets the list of all "Todo".
        /// </summary>
        /// <response code="200">Returns a collection of all "Todo".</response>
        /// <response code="500">Fail to get collection of "Todo".</response>
        /// <returns>Collection of "Todo".</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAllAsync()
        {
            try
            {
                IEnumerable<TodoDto> result = await _service.GetAllAsync();
                _logger.LogInformation("All 'Todo' getted.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when try get all 'Todo'.");
                throw;
            }
        }

        /// <summary>
        /// Gets a "Todo" by it's ID.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <response code="200">Returns "Todo".</response>
        /// <response code="404">"Todo" not found.</response>
        /// <response code="500">Fail to get "Todo".</response>
        /// <returns>"Todo".</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetByIdAsync(long id)
        {
            try
            {
                TodoDto result = await _service.GetByIdAsync(id);
                _logger.LogInformation("'Todo' getted.");

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when try get selected 'Todo'.");
                throw;
            }
        }

        /// <summary>
        /// Create new "Todo".
        /// </summary>
        /// <param name="model">Informations.</param>
        /// <response code="200">Returns created "Todo".</response>
        /// <response code="500">Fail to create "Todo".</response>
        /// <returns>Created "Todo".</returns>
        [HttpPost]
        public async Task<ActionResult<TodoDto>> AddAsync([FromBody] NewTodoDto model)
        {
            try
            {
                TodoDto result = await _service.AddAsync(model);
                _logger.LogInformation("'Todo' added.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when try get selected Todo.");
                throw;
            }
        }

        /// <summary>
        /// Update "Todo" by it's ID.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="model">Informations.</param>
        /// <response code="200">Returns updated "Todo".</response>
        /// <response code="404">"Todo" not found.</response>
        /// <response code="500">Fail to update "Todo".</response>
        /// <returns>Updated "Todo".</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDto>> UpdateAsync(long id, [FromBody] UpdateTodoDto model)
        {
            try
            {
                TodoDto result = await _service.UpdateAsync(id, model);
                _logger.LogInformation("'Todo' getted.");

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "'Todo' not found.");
                return NotFound("Not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when try get selected 'Todo'.");
                throw;
            }
        }

        /// <summary>
        /// Remove "Todo" by it's ID.
        /// </summary>
        /// <param name="id">"Todo" identifier.</param>
        /// <response code="200">Returns removed "Todo".</response>
        /// <response code="404">"Todo" not found.</response>
        /// <response code="500">Fail to remove "Todo".</response>
        /// <returns>Removed "Todo".</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoDto>> RemoveAsync(long id)
        {
            try
            {
                TodoDto result = await _service.RemoveAsync(id);
                _logger.LogInformation("'Todo' getted.");

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "'Todo' not found.");
                return BadRequest("Not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when try get selected 'Todo'.");
                throw;
            }
        }
    }
}