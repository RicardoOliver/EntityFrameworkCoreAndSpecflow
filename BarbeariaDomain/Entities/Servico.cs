
namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Servico" no banco de dados
    public class Servico
    {
        public int ServicoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
