using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaData.DataConfig
{
    // Classe de configuração para a entidade Funcionario
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(f => f.FuncionarioId);

            builder.Property(f => f.Nome).IsRequired().HasMaxLength(100);
            builder.Property(f => f.Funcao).IsRequired().HasMaxLength(100);
            builder.Property(f => f.Telefone).IsRequired().HasMaxLength(20);
            builder.Property(f => f.Salario).IsRequired().HasColumnType("decimal(10, 2)");
        }
    }
}
