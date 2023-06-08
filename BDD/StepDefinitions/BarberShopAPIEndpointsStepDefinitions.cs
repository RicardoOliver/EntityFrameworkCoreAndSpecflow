using System;
using RestSharp;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BDD.StepDefinitions
{
    [Binding]
    public class BarberShopAPIEndpointsStepDefinitions
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        string baseUrl = "https://localhost:7110";
        [Given(@"I have the following data:")]
        public void GivenIHaveTheFollowingData(Table table)
        
        {
            var data = table.Rows[0];
            var dataHora = data["dataHora"];
            var cliente = data["cliente"];
            var telefone = data["telefone"];
            var endereco = data["endereco"];
            var descricao = data["descricao"];

            client = new RestClient(baseUrl);
            request = new RestRequest("/api/BarberShop/agendar", Method.Post);
            request.AddParameter("dataHora", dataHora);
            request.AddParameter("cliente", cliente);
            request.AddParameter("telefone", telefone);
            request.AddParameter("endereco", endereco);
            request.AddParameter("descricao", descricao);
        }

        [When(@"I send a POST request to ""([^""]*)"" with the provided data")]
        public void WhenISendAPOSTRequestToWithTheProvidedData(string endpoint)
        {
            request.Resource = endpoint;
            response = client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            var actualStatusCode = (int)response.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [Then(@"the response body should contain the text ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainTheText(string expectedText)
        {
            var responseBody = response.Content;
            Assert.IsTrue(responseBody.Contains(expectedText));
        }

        [Given(@"I have an existing agendamento with ID (.*)")]
        public void GivenIHaveAnExistingAgendamentoWithID(int agendamentoId)
        {
            // Code to set up existing agendamento with given ID
        }

        [When(@"I send a POST request to ""([^""]*)"" with the provided data and agendamentoId as (.*)")]
        public void WhenISendAPOSTRequestToWithTheProvidedDataAndAgendamentoIdAs(string endpoint, int agendamentoId)
        {
            request.Resource = endpoint;
            request.AddParameter("agendamentoId", agendamentoId);
            response = client.Execute(request);
        }

        [Given(@"I have an existing cliente with ID (.*)")]
        public void GivenIHaveAnExistingClienteWithID(int clienteId)
        {
            // Code to set up existing cliente with given ID
        }

        [When(@"I send a POST request to ""([^""]*)"" with clienteId as (.*)")]
        public void WhenISendAPOSTRequestToWithClienteIdAs(string endpoint, int clienteId)
        {
            request.Resource = endpoint;
            request.AddParameter("clienteId", clienteId);
            response = client.Execute(request);
        }

        [Given(@"I have an existing funcionário with ID (.*)")]
        public void GivenIHaveAnExistingFuncionarioWithID(int funcionarioId)
        {
            // Code to set up existing funcionário with given ID
        }

        [When(@"I send a POST request to ""([^""]*)"" with funcionarioId as (.*)")]
        public void WhenISendAPOSTRequestToWithFuncionarioIdAs(string endpoint, int funcionarioId)
        {
            request.Resource = endpoint;
            request.AddParameter("funcionarioId", funcionarioId);
            response = client.Execute(request);
        }

        [Given(@"I have an existing serviço with ID (.*)")]
        public void GivenIHaveAnExistingServicoWithID(int servicoId)
        {
            // Code to set up existing serviço with given ID
        }

        [When(@"I send a POST request to ""([^""]*)"" with servicoId as (.*)")]
        public void WhenISendAPOSTRequestToWithServicoIdAs(string endpoint, int servicoId)
        {
            request.Resource = endpoint;
            request.AddParameter("servicoId", servicoId);
            response = client.Execute(request);
        }

        [Given(@"I have an existing agendamento with ID (.*) and the following updated data:")]
        public void GivenIHaveAnExistingAgendamentoWithIDAndTheFollowingUpdatedData(int agendamentoId, Table table)
        {
            // Code to set up existing agendamento with given ID and updated data
        }
        
        [Given(@"I have the following updated data:")]
        public void GivenIHaveTheFollowingUpdatedData(Table table)
        {
            // Code to retrieve the updated data from the table and store it for later use
            // You can access the data using table.Rows[index]["columnName"]
            string nome = table.Rows[0]["nome"];
            string telefone = table.Rows[0]["telefone"];
            string endereco = table.Rows[0]["endereco"];

            // Store the data in a suitable data structure or instance variables
        }
        [When(@"I send a POST request to ""([^""]*)"" with the provided updated data and agendamentoId as (.*)")]
        public void WhenISendAPOSTRequestToWithTheProvidedUpdatedDataAndAgendamentoIdAs(string endpoint, int agendamentoId)
        {
            request.Resource = endpoint;
            request.AddParameter("agendamentoId", agendamentoId);
            // Add parameters for updated data
            response = client.Execute(request);
        }

        [Given(@"I have an existing cliente with ID (.*) and the following updated data:")]
        public void GivenIHaveAnExistingClienteWithIDAndTheFollowingUpdatedData(int clienteId, Table table)
        {
            // Code to set up existing cliente with given ID and updated data
        }

        [When(@"I send a POST request to ""([^""]*)"" with the provided updated data and clienteId as (.*)")]
        public void WhenISendAPOSTRequestToWithTheProvidedUpdatedDataAndClienteIdAs(string endpoint, int clienteId)
        {
            request.Resource = endpoint;
            request.AddParameter("clienteId", clienteId);
            // Add parameters for updated data
            response = client.Execute(request);
        }

        [Given(@"I have an existing funcionário with ID (.*) and the following updated data:")]
        public void GivenIHaveAnExistingFuncionarioWithIDAndTheFollowingUpdatedData(int funcionarioId, Table table)
        {
            // Code to set up existing funcionário with given ID and updated data
        }

        [When(@"I send a POST request to ""([^""]*)"" with the provided updated data and funcionarioId as (.*)")]
        public void WhenISendAPOSTRequestToWithTheProvidedUpdatedDataAndFuncionarioIdAs(string endpoint, int funcionarioId)
        {
            request.Resource = endpoint;
            request.AddParameter("funcionarioId", funcionarioId);
            // Add parameters for updated data
            response = client.Execute(request);
        }

        [Given(@"I have an existing serviço with ID (.*) and the following updated data:")]
        public void GivenIHaveAnExistingServicoWithIDAndTheFollowingUpdatedData(int servicoId, Table table)
        {
            // Code to set up existing serviço with given ID and updated data
        }

        [When(@"I send a POST request to ""([^""]*)"" with the provided updated data and servicoId as (.*)")]
        public void WhenISendAPOSTRequestToWithTheProvidedUpdatedDataAndServicoIdAs(string endpoint, int servicoId)
        {
            request.Resource = endpoint;
            request.AddParameter("servicoId", servicoId);
            // Add parameters for updated data
            response = client.Execute(request);
        }

        [When(@"I send a GET request to ""([^""]*)""")]
        public void WhenISendAGETRequestTo(string endpoint)
        {
            request.Resource = endpoint;
            response = client.Execute(request);
        }

        [Then(@"the response body should contain a list of (.*)")]
        public void ThenTheResponseBodyShouldContainAListOf(string objectType)
        {
            var responseBody = response.Content;
            // Code to assert that the response body contains a list of the specified object type
        }
    }
}