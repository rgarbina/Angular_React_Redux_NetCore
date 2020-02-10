using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class RelacionamentoConfiguration : IEntityTypeConfiguration<Relacionamento>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Relacionamento> entity)
        {
            entity.HasKey(o => new { o.PessoaPropriaId, o.PessoaRelacionadaId });

            entity.HasOne(sc => sc.Relacionado)
                .WithMany()
                .HasForeignKey(sc => sc.PessoaRelacionadaId);

            entity.HasOne(sc => sc.TipoRelacionamento)
                .WithMany()
                .HasForeignKey(sc => sc.TipoRelacionamentoId);

            entity.HasOne(d => d.Pessoa)
                .WithMany(e => e.Relacionamentos)
                .HasForeignKey(d => d.PessoaPropriaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
