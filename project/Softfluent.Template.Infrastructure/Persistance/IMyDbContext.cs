using Microsoft.EntityFrameworkCore;
using Softfluent.Template.Core.Entities;

namespace Softfluent.Template.Infrastructure.Persistance
{
    public interface IMyDbContext
    {
        DbSet<TodoEntity> Todo { get; set; }
    }
}