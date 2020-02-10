using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Documento> entity)
        {
            entity.HasKey(o => o.DocumentoId);

            entity.HasOne(d => d.TipoDocumento)
                .WithMany()
                .HasForeignKey(d => d.TipoDocumentoId);

            entity.HasOne(d => d.Pessoa)
                .WithMany(a => a.Documentos)
                .HasForeignKey(d => d.PessoaId);
        }
    }

}
