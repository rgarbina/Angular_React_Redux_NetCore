using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class TipoEnderecoConfiguration : IEntityTypeConfiguration<TipoEndereco>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<TipoEndereco> entity)
        {
            entity.HasKey(o => o.TipoEnderecoId);

            entity.HasData(
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.None, Descricao = "Nenhum" },
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Unknown, Descricao = "Desconhecido" },
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Casa, Descricao = "Casa" },
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Apartamento, Descricao = "Apartamento" },
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Industria, Descricao = "Industria" },
                    new TipoEndereco { TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Rural, Descricao = "Rural" }
                );
        }
    }
}
