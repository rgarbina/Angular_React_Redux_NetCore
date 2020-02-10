using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> entity)
        {
            entity.HasKey(o => o.TipoDocumentoId);

            entity.HasData(
                new TipoDocumento { TipoDocumentoId = Entity.Enum.EnumTipoDocumento.None, Documento = "Nenhum" },
                new TipoDocumento { TipoDocumentoId = Entity.Enum.EnumTipoDocumento.Unknown, Documento = "Desconhecido" },
                new TipoDocumento { TipoDocumentoId = Entity.Enum.EnumTipoDocumento.CPF, Documento = "CPF" },
                new TipoDocumento { TipoDocumentoId = Entity.Enum.EnumTipoDocumento.RG, Documento = "RG" },
                new TipoDocumento { TipoDocumentoId = Entity.Enum.EnumTipoDocumento.RNE, Documento = "RNE" }
            );
        }
    }
}
