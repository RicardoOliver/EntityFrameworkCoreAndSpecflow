using BarbeariaData.DataConfig;
using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            optionsBuilder.UseSqlServer("Server=RICARDO-OLIVEIR\\SQLEXPRESS;Database=BarberShop;Trusted_Connection=True;TrustServerCertificate=true"); // Substitua "sua_string_de_conexao" pela sua string de conexão com o banco de dados

            // Desabilitar a validação do certificado SSL
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
           
            // Definir o protocolo de segurança TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
