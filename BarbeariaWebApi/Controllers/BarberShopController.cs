using BarbeariaDomain.Entities;
using BarbeariaRepositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BarbeariaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberShopController : ControllerBase
    {
        private readonly IBarbeariaRepository _barberShopService;

        public BarberShopController(IBarbeariaRepository barberShopService)
        {
            _barberShopService = barberShopService;
        }

        [HttpPost("agendar")]
        public IActionResult AgendarCorte(DateTime dataHora, string cliente, string telefone, string endereco, string descricao)
        {
            try
            {
                _barberShopService.AgendarCorte(dataHora, cliente, telefone, endereco, descricao);
                return Ok("Corte agendado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao agendar corte: {ex.Message}");
            }
        }

        [HttpPost("realizar")]
        public IActionResult RealizarCorte(int agendamentoId, string nome, string telefone)
        {
            try
            {
                _barberShopService.RealizarCorte(agendamentoId, nome, telefone);
                return Ok("Corte realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao realizar corte: {ex.Message}");
            }
        }

        [HttpPost("clientesCadastrar")]
        public IActionResult CadastrarClientes(string nome, string telefone, string endereco)
        {
            try
            {
                _barberShopService.CadastrarClientes(nome, telefone, endereco);
                return Ok("Cadastro do cliente realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar cliente: {ex.Message}");
            }
        }

        [HttpPost("funcionariosCadastrar")]
        public IActionResult CadastrarFuncionarios(string nome, string funcao, string telefone, decimal salario)
        {
            try
            {
                _barberShopService.CadastrarFuncionarios(nome, funcao, telefone, salario);
                return Ok("Cadastro do funcionario realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar funcionario: {ex.Message}");
            }
        }

        [HttpPost("servicosCadastrar")]
        public IActionResult CadastrarServico(string nome, string descricao, decimal preco)
        {
            try
            {
                _barberShopService.CadastarServicos(nome, descricao, preco);
                return Ok("Cadastro do serviço realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar serviço: {ex.Message}");
            }
        }

        [HttpPost("clientesDelete")]
        public IActionResult DeleteCliente(int clienteId)
        {
            try
            {
                _barberShopService.DeleteCliente(clienteId);
                return Ok("Cliente excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir cliente: {ex.Message}");
            }
        }

        [HttpPost("funcionariosDelete")]
        public IActionResult DeleteFuncionario(int funcionarioId)
        {
            try
            {
                _barberShopService.DeleteFuncionario(funcionarioId);
                return Ok("Funcionário excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir funcionário: {ex.Message}");
            }
        }

        [HttpPost("servicosDelete")]
        public IActionResult DeleteServico(int servicoId)
        {
            try
            {
                _barberShopService.DeleteServico(servicoId);
                return Ok("Serviço excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir serviço: {ex.Message}");
            }
        }

        [HttpPost("agendamentosUpdate")]
        public IActionResult UpdateAgendamento(Agendamento agendamento)
        {
            try
            {
                _barberShopService.UpdateAgendamento(agendamento);
                return Ok("Agendamento atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar agendamento: {ex.Message}");
            }
        }

        [HttpPost("clientesUpdate")]
        public IActionResult UpdateCliente(Cliente cliente)
        {
            try
            {
                _barberShopService.UpdateCliente(cliente);
                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        [HttpPost("funcionariosUpdate")]
        public IActionResult UpdateFuncionario(Funcionario funcionario)
        {
            try
            {
                _barberShopService.UpdateFuncionario(funcionario);
                return Ok("Funcionário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar funcionário: {ex.Message}");
            }
        }

        [HttpPost("servicosUpdate")]
        public IActionResult UpdateServico(Servico servico)
        {
            try
            {
                _barberShopService.UpdateServico(servico);
                return Ok("Serviço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar serviço: {ex.Message}");
            }
        }

        [HttpGet("clientes")]
        public IActionResult ListarClientes()
        {
            try
            {
                var clientes = _barberShopService.ListarClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar clientes: {ex.Message}");
            }
        }

        [HttpGet("funcionarios")]
        public IActionResult ListarFuncionarios()
        {
            try
            {
                var funcionarios = _barberShopService.ListarFuncionarios();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar funcionários: {ex.Message}");
            }
        }

        [HttpGet("servicos")]
        public IActionResult ListarServicos()
        {
            try
            {
                var servicos = _barberShopService.ListarServicos();
                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar serviços: {ex.Message}");
            }
        }

        [HttpGet("agendamentos")]
        public IActionResult ListarAgendamentos()
        {
            try
            {
                var agendamentos = _barberShopService.ListarAgendamentos();
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar agendamentos: {ex.Message}");
            }
        }
    }
}
