using BarbeariaDomain.Entities;

namespace BarbeariaRepositories.Interface
{
    public interface IBarbeariaRepository : IBaseRepository<Agendamento, Cliente, Funcionario, Servico>
    {
        void AgendarCorte(int clienteId, int funcionarioId, int servicoId, DateTime dataHora);
        object ListarAgendamentos();
        object ListarClientes();
        object ListarFuncionarios();
        object ListarServicos();
        void RealizarCorte(int agendamentoId);
    }

    public interface IBaseRepository<T1, T2, T3, T4>
    {
    }
}
