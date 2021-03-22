using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$.Core.Entities;

namespace $safeprojectname$.Persistance
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<TodoEntity> Todo { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMyDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTrackedEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTrackedEntities()
        {
            IEnumerable<TrackedEntity> entities = from x in ChangeTracker.Entries()
                                                  where x.Entity is IInfoEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)
                                                  select new TrackedEntity(x.Entity as IInfoEntity, x.State);

            foreach (TrackedEntity trackedEntity in entities)
            {
                DateTime now = DateTime.UtcNow;
                trackedEntity.Entity.ModificationDateTime = now;

                if (trackedEntity.State == EntityState.Added)
                {
                    trackedEntity.Entity.CreationDateTime = now;
                }
            }
        }

        private struct TrackedEntity
        {
            /// <summary>
            /// Gets the tracked entity instance.
            /// </summary>
            public IInfoEntity Entity { get; }

            /// <summary>
            /// Gets the entity state.
            /// </summary>
            public EntityState State { get; }

            /// <summary>
            /// Creates a new <see cref="TrackedEntity"/> instance.
            /// </summary>
            /// <param name="entity">Tracked entity.</param>
            /// <param name="state">Entity tracking state.</param>
            public TrackedEntity(IInfoEntity entity, EntityState state)
            {
                Entity = entity;
                State = state;
            }
        }
    }
}