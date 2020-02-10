using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class TipoContatoConfiguration : IEntityTypeConfiguration<TipoContato>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<TipoContato> entity)
        {
            entity.HasKey(o => o.TipoContatoId);
            entity.Property(o => o.TipoContatoId).ValueGeneratedNever();

            entity.HasData(
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.None, Descricao = "Nenhum" },
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.Unknown, Descricao = "Desconhecido" },
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.Celular, Descricao = "Celular" },
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.Email, Descricao = "E-Mail" },
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.RedeSocial, Descricao = "Rede Social" },
                new TipoContato { TipoContatoId = Entity.Enum.EnumTipoContato.Telefone, Descricao = "Telefone" }
            );

        }
    }
}
