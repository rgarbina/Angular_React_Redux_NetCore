using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class PessoaIdiomaConfiguration : IEntityTypeConfiguration<PessoaIdioma>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<PessoaIdioma> entity)
        {
            entity.HasKey(o =>new { o.PessoaId, o.IdiomaId });

            entity.HasOne(bc => bc.Pessoa)
                .WithMany(b => b.Idiomas)
                .HasForeignKey(bc => bc.PessoaId);

            entity.HasOne(bc => bc.Idioma)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(bc => bc.IdiomaId);
        }
    }

}
