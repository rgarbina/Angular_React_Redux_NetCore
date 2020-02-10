using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Cidade> entity)
        {
            entity.HasKey(o => o.CidadeId);
            entity.Property(c => c.Nome).HasMaxLength(155).IsRequired();

            entity.HasData(new Cidade { CidadeId = 1, Nome = "São José do Rio Preto", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 2, Nome = "Mirassol", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 3, Nome = "Bady Bassit", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 4, Nome = "Cosmorama", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 5, Nome = "Cedral", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 6, Nome = "Ipigua", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 7, Nome = "Barretos", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 8, Nome = "Uchoa", EstadoId = "SP" });
            entity.HasData(new Cidade { CidadeId = 9, Nome = "Rio de Janeiro", EstadoId = "RJ" });
            entity.HasData(new Cidade { CidadeId = 10, Nome = "Curitiba", EstadoId = "PR" });
            entity.HasData(new Cidade { CidadeId = 11, Nome = "Florianópolis", EstadoId = "SC" });
            entity.HasData(new Cidade { CidadeId = 12, Nome = "Itajaí", EstadoId = "SC" });
            entity.HasData(new Cidade { CidadeId = 13, Nome = "Brusque", EstadoId = "SC" });
        }
    }

}
