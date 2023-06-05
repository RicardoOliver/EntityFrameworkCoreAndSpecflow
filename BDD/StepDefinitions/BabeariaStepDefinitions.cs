using BarbeariaDomain.Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Text;
using TechTalk.SpecFlow.Assist;

namespace BDD.StepDefinitions
{
    [Binding]
    public class BabeariaStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _httpResponse;

        public BabeariaStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"um cliente com os seguintes detalhes")]
        public void DadoUmClienteComOsSeguintesDetalhes(Table table)
        {
            var cliente = table.CreateInstance<Cliente>();
            _scenarioContext.Set(cliente);
        }

        [Given(@"um funcionário com os seguintes detalhes")]
        public void EUmFuncionarioComOsSeguintesDetalhes(Table table)
        {
            var funcionario = table.CreateInstance<Funcionario>();
            _scenarioContext.Set(funcionario);
        }

        [Given(@"um serviço com os seguintes detalhes")]
        public void EUmServicoComOsSeguintesDetalhes(Table table)
        {
            var servico = table.CreateInstance<Servico>();
            _scenarioContext.Set(servico);
        }

        [When(@"o cliente agenda o serviço com o funcionário em uma determinada data e hora")]
        public async Task QuandoOClienteAgendaOServicoComOFuncionarioEmUmaDeterminadaDataEHora()
        {
            var cliente = _scenarioContext.Get<Cliente>();
            var funcionario = _scenarioContext.Get<Funcionario>();
            var servico = _scenarioContext.Get<Servico>();

            var agendamento = new Agendamento
            {
                ClienteId = cliente.ClienteId,
                FuncionarioId = funcionario.FuncionarioId,
                ServicoId = servico.ServicoId,
                DataHora = DateTime.Now
            };

            // Enviar a solicitação HTTP para a API
            var json = JsonConvert.SerializeObject(agendamento);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpResponse = await _httpClient.PostAsync("/api/BarberShop/agendamentos", content);
        }

        [Then(@"o agendamento é criado com sucesso")]
        public async Task EntaoOAgendamentoECriadoComSucesso()
        {
            Assert.Equals(HttpStatusCode.Created, _httpResponse.StatusCode);

            var responseContent = await _httpResponse.Content.ReadAsStringAsync();
            var agendamento = JsonConvert.DeserializeObject<Agendamento>(responseContent);

            Assert.NotNull(agendamento);
            Assert.AreNotEqual(0, agendamento.AgendamentoId);
        }

        [Given(@"que existem os seguintes agendamentos")]
        public void DadoQueExistemOsSeguintesAgendamentos(Table table)
        {
            var agendamentos = table.CreateSet<Agendamento>();
            _scenarioContext.Set(agendamentos);
        }

        [When(@"o cliente solicita os agendamentos")]
        public async Task QuandoOClienteSolicitaOsAgendamentos()
        {
            _httpResponse = await _httpClient.GetAsync("/api/BarberShop/agendamentos");
        }

        [Then(@"os agendamentos são retornados corretamente")]
        public async Task EntaoOsAgendamentosSaoRetornadosCorretamente()
        {
            Assert.Equals(HttpStatusCode.OK, _httpResponse.StatusCode);

            var responseContent = await _httpResponse.Content.ReadAsStringAsync();
            var agendamentos = JsonConvert.DeserializeObject<List<Agendamento>>(responseContent);

            var expectedAgendamentos = _scenarioContext.Get<IEnumerable<Agendamento>>();

            Assert.Equals(expectedAgendamentos.Count(), agendamentos.Count());

            foreach (var expectedAgendamento in expectedAgendamentos)
            {
                Assert.Contains(expectedAgendamento, agendamentos);
            }
        }
    }
}