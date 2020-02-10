using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class CategoriaContatoConfiguration : IEntityTypeConfiguration<CategoriaContato>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<CategoriaContato> entity)
        {
            entity.HasKey(o => o.CategoriaContatoId);

            entity.HasMany(d => d.Contatos)
                .WithOne(a=> a.CategoriaContato)
                .HasForeignKey(d => d.CategoriaContatoId)
                .IsRequired();

            entity.HasData
                (
                    new CategoriaContato { CategoriaContatoId = Entity.Enum.EnumCategoriaContato.None, Descricao = "Nenhum" },
                    new CategoriaContato { CategoriaContatoId = Entity.Enum.EnumCategoriaContato.Unknown, Descricao = "Desconhecido" },
                    new CategoriaContato { CategoriaContatoId = Entity.Enum.EnumCategoriaContato.Residencial, Descricao = "Residencia" },
                    new CategoriaContato { CategoriaContatoId = Entity.Enum.EnumCategoriaContato.Comercial, Descricao = "Comercio" }
                );
        }
    }

}
