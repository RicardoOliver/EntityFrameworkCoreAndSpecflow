
namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Agendamento" no banco de dados
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int ServicoId { get; set; }
        public DateTime DataHora { get; set; }

        public Cliente? Cliente { get; set; } // Relacionamento com a tabela "Cliente"
        public Funcionario? Funcionario { get; set; } // Relacionamento com a tabela "Funcionario"
        public Servico? Servico { get; set; } // Relacionamento com a tabela "Servico"
    }
}

