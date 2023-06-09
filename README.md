# EntityFrameworkCoreAndSpecflow


<p>As entidades são classes que representam as tabelas do banco de dados. No código fornecido, temos quatro entidades: Cliente, Funcionario, Servico e Agendamento. Cada uma dessas entidades possui propriedades que correspondem às colunas da tabela no banco de dados.

Exemplo:

    A entidade Cliente possui as propriedades ClienteId, Nome, Telefone e Endereco.
    A entidade Funcionario possui as propriedades FuncionarioId, Nome, Funcao, Telefone e Salario.

Essas entidades servirão como base para a criação das tabelas no banco de dados.

    Criação do contexto do banco de dados:

O contexto do banco de dados é uma classe que herda da classe DbContext do Entity Framework Core. Essa classe é responsável por mapear as entidades para as tabelas no banco de dados e gerenciar as operações de acesso aos dados.

No código fornecido, temos a classe BarberShopContext que representa o contexto do banco de dados da barbearia. Essa classe herda de DbContext e possui propriedades DbSet para cada uma das entidades (tabelas) do banco de dados.</P>

```C#
public class BarberShopContext : DbContext
{
   ﻿using BarbeariaData.DataConfig;
using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaData.Contexto
{
    // Classe de contexto que representa o banco de dados
    public class BarberShopContext : DbContext
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options)
               : base(options)
        {
        }
        // Defina suas propriedades DbSet e configure seu modelo
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações para as entidades
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new ServicoConfiguration());
            modelBuilder.ApplyConfiguration(new AgendamentoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(""); // Substitua "sua_string_de_conexao" pela sua string de conexão com o banco de dados
        }
    }
}
```
<p>Passo 1: Configurar o projeto

    Crie um novo projeto do tipo "Class Library" no Visual Studio.
    Adicione as referências necessárias ao projeto, como Microsoft.Extensions.DependencyInjection, SpecFlow e SpecFlow.Assist.Dynamic.

Passo 2: Escrever as especificações do SpecFlow

    Crie um arquivo de recurso chamado "BarberShopApi.feature" e adicione-o ao projeto.
    Escreva as especificações do SpecFlow no arquivo "BarberShopApi.feature" da seguinte forma:</p>
    
```specflow
Funcionalidade: API da Barbearia
    Como cliente da barbearia
    Eu quero agendar um serviço e obter informações sobre os agendamentos

    Contexto:
        Dado que a API da Barbearia está em execução

    Cenário: Agendar um serviço
        Dado um cliente com os seguintes detalhes
            | Nome       | Telefone       | Endereco       |
            | John Doe   | (11) 987654321 | 123 Main Street|
        E um funcionário com os seguintes detalhes
            | Nome       | Função         | Telefone       | Salário |
            | Jane Smith | Barbeiro       | (11) 123456789 | 2000.00 |
        E um serviço com os seguintes detalhes
            | Nome       | Descrição       | Preço   |
            | Corte      | Serviço de corte| 50.00   |
        Quando o cliente agenda o serviço com o funcionário em uma determinada data e hora
        Então o agendamento é criado com sucesso

    Cenário: Obter informações sobre os agendamentos
        Dado que existem os seguintes agendamentos
            | Cliente     | Funcionário   | Serviço   | DataHora           |
            | John Doe    | Jane Smith    | Corte     | 2023-06-04T10:00:00|
            | Jane Doe    | John Smith    | Barbear   | 2023-06-05T14:30:00|
        Quando o cliente solicita os agendamentos
        Então os agendamentos são retornados corretamente
```
[![asciicast](https://img.youtube.com/vi/vt5fpE0bzSY/0.jpg)](https://github.com/RicardoOliver/EntityFrameworkCoreAndSpecflow/assets/20847532/6d72c20a-8bc2-4d2a-abd8-b83417bdf38e)



![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)
 
 
 [![GitHub stars](https://img.shields.io/github/stars/RicardoOliver?style=social)](https://github.com/RicardoOliver)

