using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class TipoRelacionamentoConfiguration : IEntityTypeConfiguration<TipoRelacionamento>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<TipoRelacionamento> entity)
        {
            entity.HasKey(o => o.TipoRelacionamentoId);

            entity.HasData(
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.None, Descricao = "Nenhum" },
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.Unknown, Descricao = "Desconhecido" },
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.Familiar, Descricao = "Familiar" },
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.Amoroso, Descricao = "Amoroso" },
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.Amizade, Descricao = "Amizade" },
                    new TipoRelacionamento { TipoRelacionamentoId = Entity.Enum.EnumTipoRelacionamento.Profissional, Descricao = "Profissional" }
                );
        }
    }
}
