using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Softfluent.Template.Core.Dtos.Todo;
using Softfluent.Template.Core.Entities;
using Softfluent.Template.Core.Extensions;
using Softfluent.Template.Core.Interfaces.IRepositories;
using Softfluent.Template.Core.Interfaces.IServices;

namespace ProgressiveWebApp.Core.Services
{
    [Injectable]
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _repository;

        /// <summary>
        /// Creates a new <see cref="TodoService"/> instance.
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"></param>
        /// <param name="repository"><see cref="ITodoRepository"></param>
        public TodoService(IMapper mapper,
            ITodoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<TodoDto>> GetAllAsync()
        {
            IEnumerable<TodoEntity> users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TodoDto>>(users);
        }

        public async Task<TodoDto> GetByIdAsync(long id)
        {
            TodoEntity user = await _repository.GetByIdAsync(id);
            return _mapper.Map<TodoDto>(user);
        }

        public async Task<TodoDto> AddAsync(NewTodoDto model)
        {
            TodoEntity entity = _mapper.Map<TodoEntity>(model);
            TodoEntity user = await _repository.AddAsync(entity);
            return _mapper.Map<TodoDto>(user);
        }

        public async Task<TodoDto> UpdateAsync(long id, UpdateTodoDto model)
        {
            TodoEntity entity = await _repository.GetByIdAsync(id);
            _mapper.Map(model, entity);

            TodoEntity user = await _repository.UpdateAsync(entity);
            return _mapper.Map<TodoDto>(user);
        }

        public async Task<TodoDto> RemoveAsync(long id)
        {
            TodoDto entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(id), "User not found.");
            }

            TodoEntity user = await _repository.RemoveAsync(id);
            return _mapper.Map<TodoDto>(user);
        }
    }
}