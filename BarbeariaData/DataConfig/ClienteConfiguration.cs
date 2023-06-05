using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BarbeariaDomain.Entities;

namespace BarbeariaData.DataConfig
{
    // Classe de configuração para a entidade Cliente
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.ClienteId);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Endereco).IsRequired().HasMaxLength(200);
        }
    }
}