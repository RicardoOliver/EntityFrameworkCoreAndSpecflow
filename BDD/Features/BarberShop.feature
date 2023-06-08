Feature: BarberShop API Endpoints
    As a user of the BarberShop API
    I want to be able to interact with various endpoints
    So that I can perform CRUD operations on the entities

Scenario: Agendar corte
    Given I have the following data:
        | dataHora             | cliente          | telefone  | endereco            | descricao |
        | 2023-06-08T10:00:00  | João da Silva    | 123456789 | Rua Principal, 123  | Corte de cabelo masculino   |
    When I send a POST request to "/api/BarberShop/agendar" with the provided data
    Then the response status code should be 200
    And the response body should contain the text "Corte agendado com sucesso."

Scenario: Realizar corte
    Given I have an existing agendamento with ID 1
    And I have the following data:
        | nome    | telefone   |
        | John    | 1234567890 |
    When I send a POST request to "/api/BarberShop/realizar" with the provided data and agendamentoId as 1
    Then the response status code should be 200
    And the response body should contain the text "Corte realizado com sucesso."

Scenario: Cadastrar cliente
    Given I have the following data:
        | nome  | telefone   | endereco  |
        | John  | 1234567890 | Test St.  |
    When I send a POST request to "/api/BarberShop/clientesCadastrar" with the provided data
    Then the response status code should be 200
    And the response body should contain the text "Cadastro do cliente realizado com sucesso."

Scenario: Cadastrar funcionário
    Given I have the following data:
        | nome  | funcao    | telefone   | salario |
        | John  | Barber    | 1234567890 | 5000.00 |
    When I send a POST request to "/api/BarberShop/funcionariosCadastrar" with the provided data
    Then the response status code should be 200
    And the response body should contain the text "Cadastro do funcionario realizado com sucesso."

Scenario: Cadastrar serviço
    Given I have the following data:
        | nome     | descricao       | preco   |
        | Haircut  | Standard cut   | 50.00   |
    When I send a POST request to "/api/BarberShop/servicosCadastrar" with the provided data
    Then the response status code should be 200
    And the response body should contain the text "Cadastro do serviço realizado com sucesso."

Scenario: Excluir cliente
    Given I have an existing cliente with ID 1
    When I send a POST request to "/api/BarberShop/clientesDelete" with clienteId as 1
    Then the response status code should be 200
    And the response body should contain the text "Cliente excluído com sucesso."

Scenario: Excluir funcionário
    Given I have an existing funcionário with ID 1
    When I send a POST request to "/api/BarberShop/funcionariosDelete" with funcionarioId as 1
    Then the response status code should be 200
    And the response body should contain the text "Funcionário excluído com sucesso."

Scenario: Excluir serviço
    Given I have an existing serviço with ID 1
    When I send a POST request to "/api/BarberShop/servicosDelete" with servicoId as 1
    Then the response status code should be 200
    And the response body should contain the text "Serviço excluído com sucesso."

Scenario: Atualizar agendamento
    Given I have an existing agendamento with ID 1
    And I have the following updated data:
        | dataHora             | cliente | telefone   | endereco  | descricao |
        | 2023-06-15 14:00:00  | John    | 1234567890 | Test St.  | New cut   |
    When I send a POST request to "/api/BarberShop/agendamentosUpdate" with the provided updated data and agendamentoId as 1
    Then the response status code should be 200
    And the response body should contain the text "Agendamento atualizado com sucesso."

Scenario: Atualizar cliente
    Given I have an existing cliente with ID 1
    And I have the following updated data:
        | nome    | telefone   | endereco      |
        | John    | 1234567890 | Updated St.   |
    When I send a POST request to "/api/BarberShop/clientesUpdate" with the provided updated data and clienteId as 1
    Then the response status code should be 200
    And the response body should contain the text "Cliente atualizado com sucesso."

Scenario: Atualizar funcionário
    Given I have an existing funcionário with ID 1
    And I have the following updated data:
        | nome    | funcao    | telefone   | salario |
        | John    | Stylist   | 1234567890 | 6000.00 |
    When I send a POST request to "/api/BarberShop/funcionariosUpdate" with the provided updated data and funcionarioId as 1
    Then the response status code should be 200
    And the response body should contain the text "Funcionário atualizado com sucesso."

Scenario: Atualizar serviço
    Given I have an existing serviço with ID 1
    And I have the following updated data:
        | nome     | descricao       | preco   |
        | Haircut  | New cut         | 60.00   |
    When I send a POST request to "/api/BarberShop/servicosUpdate" with the provided updated data and servicoId as 1
    Then the response status code should be 200
    And the response body should contain the text "Serviço atualizado com sucesso."

Scenario: Listar clientes
    When I send a GET request to "/api/BarberShop/clientes"
    Then the response status code should be 200
    And the response body should contain a list of clientes

Scenario: Listar funcionários
    When I send a GET request to "/api/BarberShop/funcionarios"
    Then the response status code should be 200
    And the response body should contain a list of funcionários

Scenario: Listar serviços
    When I send a GET request to "/api/BarberShop/servicos"
    Then the response status code should be 200
    And the response body should contain a list of serviços

Scenario: Listar agendamentos
    When I send a GET request to "/api/BarberShop/agendamentos"
    Then the response status code should be 200
    And the response body should contain a list of agendamentos
