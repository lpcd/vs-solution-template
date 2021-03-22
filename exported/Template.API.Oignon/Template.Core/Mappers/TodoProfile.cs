using AutoMapper;
using $safeprojectname$.Dtos.Todo;
using $safeprojectname$.Entities;

namespace $safeprojectname$.Mappers
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