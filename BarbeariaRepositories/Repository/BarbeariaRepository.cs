using BarbeariaData.Contexto;
using BarbeariaDomain.Entities;
using BarbeariaRepositories.Interface;
using System;
using System.Linq;

namespace BarbeariaRepositories.Repository
{
    public class BarbeariaRepository : IBarbeariaRepository
    {
        private readonly BarberShopContext _dbContext;

        public BarbeariaRepository(BarberShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AgendarCorte(DateTime dataHora, string cliente, string telefone, string endereco, string descricao)
        {
            var agendamento = new Agendamento
            {
                DataHora = dataHora,
                Cliente = cliente,
                Telefone = telefone,
                Endereco = endereco,
                Descricao = descricao
            };

            _dbContext.Agendamentos.Add(agendamento);
            _dbContext.SaveChanges();
        }

        public void CadastarServicos(string nome, string descricao, decimal preco)
        {
            var servico = new Servico
            {
                Nome = nome,
                Descricao = descricao,
                Preco = preco
            };

            _dbContext.Servicos.Add(servico);
            _dbContext.SaveChanges();
        }

        public void CadastrarClientes(string nome, string telefone, string endereco)
        {
            var cliente = new Cliente
            {
                Nome = nome,
                Telefone = telefone,
                Endereco = endereco
            };

            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void CadastrarFuncionarios(string nome, string funcao, string telefone, decimal salario)
        {
            var funcionario = new Funcionario
            {
                Nome = nome,
                Funcao = funcao,
                Telefone = telefone,
                Salario = salario
            };

            _dbContext.Funcionarios.Add(funcionario);
            _dbContext.SaveChanges();
        }

        public void RealizarCorte(int agendamentoId, string nome, string telefone)
        {
            var agendamento = _dbContext.Agendamentos.FirstOrDefault(a => a.AgendamentoId == agendamentoId);

            if (agendamento != null)
            {
                _dbContext.Agendamentos.Remove(agendamento);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteAgendamento(int agendamentoId)
        {
            var agendamento = _dbContext.Agendamentos.Remove(new Agendamento { AgendamentoId = agendamentoId });
            _dbContext.SaveChanges();
        }

        public void DeleteCliente(int clienteId)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.ClientId == clienteId);

            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteFuncionario(int funcionarioId)
        {
            var funcionario = _dbContext.Funcionarios.FirstOrDefault(f => f.FuncionarioId == funcionarioId);

            if (funcionario != null)
            {
                _dbContext.Funcionarios.Remove(funcionario);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteServico(int servicoId)
        {
            var servico = _dbContext.Servicos.FirstOrDefault(s => s.ServicoId == servicoId);

            if (servico != null)
            {
                _dbContext.Servicos.Remove(servico);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateAgendamento(Agendamento agendamento)
        {
            _dbContext.Agendamentos.Update(agendamento);
            _dbContext.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            _dbContext.Funcionarios.Update(funcionario);
            _dbContext.SaveChanges();
        }

        public void UpdateServico(Servico servico)
        {
            _dbContext.Servicos.Update(servico);
            _dbContext.SaveChanges();
        }

        object IBarbeariaRepository.ListarAgendamentos()
        {
            return ListarAgendamentos();
        }

        object ListarAgendamentos()
        {
            return _dbContext.Agendamentos.ToList();
        }

        object IBarbeariaRepository.ListarClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        object IBarbeariaRepository.ListarFuncionarios()
        {
            return _dbContext.Funcionarios.ToList();
        }

        object IBarbeariaRepository.ListarServicos()
        {
            return _dbContext.Servicos.ToList();
        }
    }
}