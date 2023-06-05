using BarbeariaData.Contexto;
using BarbeariaDomain.Entities;
using BarbeariaRepositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaRepositories.Repository
{
    public class BarbeariaRepository : IBarbeariaRepository
    {

        private readonly BarberShopContext _dbContext;

        public BarbeariaRepository(BarberShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AgendarCorte(int clienteId, int funcionarioId, int servicoId, DateTime dataHora)
        {
            // Lógica para agendar um corte
            var agendamento = new Agendamento
            {
                ClienteId = clienteId,
                FuncionarioId = funcionarioId,
                ServicoId = servicoId,
                DataHora = dataHora
            };

            _dbContext.Agendamentos.Add(agendamento);
            _dbContext.SaveChanges();
        }

        public void RealizarCorte(int agendamentoId)
        {
            // Lógica para realizar um corte
            var agendamento = _dbContext.Agendamentos.FirstOrDefault(a => a.AgendamentoId == agendamentoId);

            if (agendamento != null)
            {
                // Realizar o corte...
                _dbContext.Agendamentos.Remove(agendamento);
                _dbContext.SaveChanges();
            }
        }

        public List<Cliente> ListarClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        public List<Funcionario> ListarFuncionarios()
        {
            return _dbContext.Funcionarios.ToList();
        }

        public List<Servico> ListarServicos()
        {
            return _dbContext.Servicos.ToList();
        }

        public List<Agendamento> ListarAgendamentos()
        {
            return _dbContext.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Funcionario)
                .Include(a => a.Servico)
                .ToList();
        }

        object IBarbeariaRepository.ListarAgendamentos()
        {
            throw new NotImplementedException();
        }

        object IBarbeariaRepository.ListarClientes()
        {
            throw new NotImplementedException();
        }

        object IBarbeariaRepository.ListarFuncionarios()
        {
            throw new NotImplementedException();
        }

        object IBarbeariaRepository.ListarServicos()
        {
            throw new NotImplementedException();
        }
    }
}
