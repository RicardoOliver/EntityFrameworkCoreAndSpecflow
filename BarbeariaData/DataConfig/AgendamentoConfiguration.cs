using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaData.DataConfig
{
    // Classe de configuração para a entidade Agendamento
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(a => a.AgendamentoId);

            builder.Property(a => a.DataHora).IsRequired();

            // Configura o relacionamento entre as entidades Agendamento e Cliente
            builder.HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configura o relacionamento entre as entidades Agendamento e Funcionario
            builder.HasOne(a => a.Funcionario)
                .WithMany()
                .HasForeignKey(a => a.FuncionarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configura o relacionamento entre as entidades Agendamento e Servico
            builder.HasOne(a => a.Servico)
                .WithMany()
                .HasForeignKey(a => a.ServicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
