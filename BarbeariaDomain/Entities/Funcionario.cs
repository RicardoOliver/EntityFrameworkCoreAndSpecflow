
namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Funcionario" no banco de dados
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string? Nome { get; set; }
        public string? Funcao { get; set; }
        public string? Telefone { get; set; }
        public decimal Salario { get; set; }
    }
}
