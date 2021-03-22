using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softfluent.Template.Core.Entities;

namespace Softfluent.Template.Infrastructure.EntitiesConfigurations
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            /* Global */
            builder.ToTable(nameof(TodoEntity).Replace("Entity", ""));

            /* Primary Key */
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).IsRequired().ValueGeneratedOnAdd();

            /* Informations */
            builder.Property(x => x.CreationDateTime).HasColumnType(nameof(DateTime));
            builder.Property(x => x.ModificationDateTime).HasColumnType(nameof(DateTime));

            /* Owns */
            builder.Property(x => x.Label).HasMaxLength(256);
        }
    }
}