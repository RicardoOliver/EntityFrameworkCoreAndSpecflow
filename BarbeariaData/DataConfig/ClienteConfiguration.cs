using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaData.DataConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Endereco).IsRequired().HasMaxLength(200);
        }
    }
}
