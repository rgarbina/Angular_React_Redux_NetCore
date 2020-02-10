using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Contato> entity)
        {
            entity.HasKey(o => o.ContatoId);

            entity.HasOne(d => d.TipoContato)
                .WithMany()
                .HasForeignKey(d => d.TipoContatoId);
        }
    }

}
