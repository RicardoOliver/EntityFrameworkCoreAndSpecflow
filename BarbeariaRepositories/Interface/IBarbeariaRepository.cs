using BarbeariaDomain.Entities;
using System;

namespace BarbeariaRepositories.Interface
{
    public interface IBarbeariaRepository : IBaseRepository<Agendamento, Cliente, Funcionario, Servico>
    {
        void AgendarCorte(DateTime dataHora, string cliente, string telefone, string endereco, string descricao);
        void RealizarCorte(int agendamentoId, string nome, string telefone);
        void CadastrarClientes(string nome, string telefone, string endereco);
        void CadastrarFuncionarios(string nome, string funcao, string telefone, decimal salario);
        void CadastarServicos(string nome, string descricao, decimal preco);
        void DeleteAgendamento(int agendamentoId);
        void DeleteCliente(int clienteId);
        void DeleteFuncionario(int funcionarioId);
        void DeleteServico(int servicoId);
        void UpdateAgendamento(Agendamento agendamento);
        void UpdateCliente(Cliente cliente);
        void UpdateFuncionario(Funcionario funcionario);
        void UpdateServico(Servico servico);
        object ListarAgendamentos();
        object ListarClientes();
        object ListarFuncionarios();
        object ListarServicos();
    }
}
