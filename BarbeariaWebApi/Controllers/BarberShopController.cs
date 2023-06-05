using BarbeariaRepositories.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AgendarCorte(int clienteId, int funcionarioId, int servicoId, DateTime dataHora)
        {
            try
            {
                _barberShopService.AgendarCorte(clienteId, funcionarioId, servicoId, dataHora);
                return Ok("Corte agendado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao agendar corte: {ex.Message}");
            }
        }

        [HttpPost("realizar")]
        public IActionResult RealizarCorte(int agendamentoId)
        {
            try
            {
                _barberShopService.RealizarCorte(agendamentoId);
                return Ok("Corte realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao realizar corte: {ex.Message}");
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
