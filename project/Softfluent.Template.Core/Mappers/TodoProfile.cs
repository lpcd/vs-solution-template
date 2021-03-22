using AutoMapper;
using Softfluent.Template.Core.Dtos.Todo;
using Softfluent.Template.Core.Entities;

namespace Softfluent.Template.Core.Mappers
{
    /// <summary>
    ///  Provides an auto-mapper custom profile to map <see cref="TodoEntity"/> to <see cref="TodoDto"/>.
    /// </summary>
    public class TodoProfile : Profile
    {
        /// <summary>
        /// Creates a new <see cref="TodoProfile"/> instance.
        /// </summary>
        public TodoProfile()
        {
            CreateMap<NewTodoDto, TodoEntity>();
            CreateMap<UpdateTodoDto, TodoEntity>();
            CreateMap<TodoEntity, TodoDto>().ReverseMap();
        }
    }
}