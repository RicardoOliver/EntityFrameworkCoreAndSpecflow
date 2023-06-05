using BarbeariaDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace BarbeariaData.DataConfig
{
    // Classe de configuração para a entidade Servico
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(s => s.ServicoId);

            builder.Property(s => s.Nome).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Preco).IsRequired().HasColumnType("decimal(10, 2)");
        }
    }
}
