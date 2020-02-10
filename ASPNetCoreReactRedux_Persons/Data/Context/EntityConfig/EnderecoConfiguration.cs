using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Endereco> entity)
        {
            entity.HasKey(o => o.EnderecoId);
            entity.Property(c => c.Numero).HasMaxLength(5);
            entity.Property(c => c.Logradouro).IsRequired();

            entity.HasOne(d => d.Cidade)
                .WithMany(d=> d.Enderecos)
                .HasForeignKey(d => d.CidadeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.TipoEndereco)
                .WithMany()
                .HasForeignKey(d => d.TipoEnderecoId);
        }
    }

}
