using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity.HasKey(o => o.UF);

            entity.HasMany(d => d.Cidades)
                .WithOne(e => e.Estado)
                .IsRequired();

            entity.HasData(
                    new Estado { Nome = "Acre", UF = "AC" },
                    new Estado { Nome = "Alagoas", UF = "AL" },
                    new Estado { Nome = "Amapá", UF = "AP" },
                    new Estado { Nome = "Amazonas", UF = "AM" },
                    new Estado { Nome = "Bahia", UF = "BA" },
                    new Estado { Nome = "Ceará", UF = "CE" },
                    new Estado { Nome = "Distrito Federal", UF = "DF" },
                    new Estado { Nome = "Espírito Santo", UF = "ES" },
                    new Estado { Nome = "Goiás", UF = "GO" },
                    new Estado { Nome = "Maranhão", UF = "MA" },
                    new Estado { Nome = "Mato Grosso", UF = "MT" },
                    new Estado { Nome = "Mato Grosso do Sul", UF = "MS" },
                    new Estado { Nome = "Minas Gerais", UF = "MG" },
                    new Estado { Nome = "Pará", UF = "PA" },
                    new Estado { Nome = "Paraíba", UF = "PB" },
                    new Estado { Nome = "Paraná", UF = "PR" },
                    new Estado { Nome = "Pernambuco", UF = "PE" },
                    new Estado { Nome = "Piauí", UF = "PI" },
                    new Estado { Nome = "Rio de Janeiro", UF = "RJ" },
                    new Estado { Nome = "Rio Grande do Norte", UF = "RN" },
                    new Estado { Nome = "Rio Grande do Sul", UF = "RS" },
                    new Estado { Nome = "Rondônia", UF = "RO" },
                    new Estado { Nome = "Roraima", UF = "RR" },
                    new Estado { Nome = "Santa Catarina", UF = "SC" },
                    new Estado { Nome = "São Paulo", UF = "SP" },
                    new Estado { Nome = "Sergipe", UF = "SE" },
                    new Estado { Nome = "Tocantins", UF = "TO" }
                );

        }
    }
}
