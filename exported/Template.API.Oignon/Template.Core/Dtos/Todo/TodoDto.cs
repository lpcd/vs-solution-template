using System;

namespace $safeprojectname$.Dtos.Todo
{
    public class TodoDto : NewTodoDto
    {
        public long ID { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
    }
}