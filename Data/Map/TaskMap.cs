using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(255);
            builder.Property(x => x.Status)
                .IsRequired();
            builder.Property(x => x.IdUser)
                .IsRequired();
        }
    }
}
