using SistemadeTarefas.Models.Enum;

namespace SistemadeTarefas.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; } // 0 = Pendente, 1 = Em Andamento, 2 = Concluída
        public int IdUser { get; set; } // Foreign key to User table
    }
}
