using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Idioma> entity)
        {
            entity.HasKey(o => o.IdiomaId);

            //entity.HasMany(d => d.Pessoas)
            //    .WithOne(d => d.Idioma);

            entity.HasData(
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.None, LinguaIdioma = "Nenhum" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Unknown, LinguaIdioma = "Desconhecido" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Portugues, LinguaIdioma = "Portugues" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Ingles, LinguaIdioma = "Ingles" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Frances, LinguaIdioma = "Frances" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Chines, LinguaIdioma = "Chines" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Russo, LinguaIdioma = "Russo" },
                    new Idioma { IdiomaId = Entity.Enum.EnumIdioma.Japones, LinguaIdioma = "Japones" }
                );
        }
    }

}
