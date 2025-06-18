using System.ComponentModel;

namespace SistemadeTarefas.Models.Enum
{
    public enum StatusTask
    {
        [Description("Pendente")]
        Doing = 0, // Pendente
        [Description("Em Andamento")]
        InProgress = 1, // Em Andamento
        [Description("Concluída")]
        Done = 2 // Concluída
    }
}
