using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Softfluent.Template.Core.Entities;
using Softfluent.Template.Core.Extensions;
using Softfluent.Template.Core.Interfaces.IRepositories;
using Softfluent.Template.Infrastructure.Persistance;

namespace Softfluent.Template.Infrastructure.Repositories
{
    [Injectable]
    public class TodoRepository : ITodoRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<TodoEntity> _dbSet;

        public TodoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TodoEntity>();
        }

        public async Task<IEnumerable<TodoEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<TodoEntity> GetByIdAsync(long id)
            => await _dbSet.FirstOrDefaultAsync(x => x.ID == id);

        public async Task<TodoEntity> AddAsync(TodoEntity entity)
        {
            EntityEntry<TodoEntity> added = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<TodoEntity> UpdateAsync(TodoEntity entity)
        {
            EntityEntry<TodoEntity> updated = _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return updated.Entity;
        }

        public async Task<TodoEntity> RemoveAsync(long id)
        {
            TodoEntity user = await GetByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(id), "User not found.");
            }

            _dbSet.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}