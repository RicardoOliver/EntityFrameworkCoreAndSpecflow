Feature: API da Barbearia
    Como cliente da barbearia
    Eu quero agendar um serviço e obter informações sobre os agendamentos

    Background:
        Dado que a API da Barbearia está em execução

    Scenario Outline: Agendar um serviço
        Given um cliente com os seguintes detalhes
            | Nome       | Telefone       | Endereco            |
            | John Doe   | (11) 987654321 | 123 Main Street     |
        And um funcionário com os seguintes detalhes
            | Nome       | Função       | Telefone          | Salário |
            | Jane Smith | Barbeiro     | (11) 123456789   | 2000.00 |
        And um serviço com os seguintes detalhes
            | Nome       | Descrição         | Preço   |
            | Corte      | Serviço de corte  | 50.00   |
        When o cliente agenda o serviço com o funcionário em uma determinada data e hora
        Then o agendamento é criado com sucesso

    Scenario Outline: Obter informações sobre os agendamentos
        Given que existem os seguintes agendamentos
            | Cliente     | Funcionário   | Serviço   | DataHora               |
            | John Doe    | Jane Smith    | Corte     | 2023-06-04T10:00:00    |
            | Jane Doe    | John Smith    | Barbear   | 2023-06-05T14:30:00    |
        When o cliente solicita os agendamentos
        Then os agendamentos são retornados corretamente
