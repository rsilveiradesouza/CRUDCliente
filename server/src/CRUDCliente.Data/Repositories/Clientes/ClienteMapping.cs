using CRUDCliente.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDCliente.Data.Repositories.Clientes
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(a => a.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(a => a.Cpf).HasColumnName("Cpf").IsRequired();
            builder.Property(a => a.Celular).HasColumnName("Celular");
            builder.Property(a => a.Email).HasColumnName("Email");
        }
    }
}