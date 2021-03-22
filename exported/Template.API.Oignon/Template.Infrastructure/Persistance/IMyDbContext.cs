using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$.Core.Entities;

namespace $safeprojectname$.Persistance
{
    public interface IMyDbContext
    {
        DbSet<TodoEntity> Todo { get; set; }
    }
}