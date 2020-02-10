using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Context.EntityConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Pessoa> entity)
        {
            entity.HasKey(o => o.PessoaId);

            entity.Property(t => t.Nome)
                .IsRequired();

            entity.Property(t => t.SobreNome)
                .IsRequired();

            entity.Property(t => t.DataInclusao)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");

            entity.Property(t => t.Nome)
                .IsRequired();

            entity.Property(t => t.Ativado)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasOne(d => d.Endereco)
                .WithMany()
                .HasForeignKey(d => d.EnderecoId)
                .IsRequired();

            entity.HasOne(d => d.Celular)
                .WithMany()
                .HasForeignKey(d => d.CelularId)
                .IsRequired();

            entity.HasOne(d => d.Email)
                .WithMany()
                .HasForeignKey(d => d.EmailId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(d => d.Documentos)
                .WithOne(a=> a.Pessoa)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            //entity.HasData
            //    (
            //        new Pessoa
            //        {
            //            PessoaId = 1,
            //            Nome = "Raphael",
            //            SobreNome = "Garbina",
            //            Pseudonimo = "Alastor",
            //            Sexo = true,
            //            DataNascimento = new DateTime(1994, 05, 03),
            //            Endereco = new Endereco
            //            {
            //                EnderecoId = 1,
            //                TipoEnderecoId = Entity.Enum.EnumTipoEndereco.Casa,
            //                Logradouro = "Rua Joana Darc",
            //                Numero = "750",
            //                Bairro = "Maria Lucia",
            //                Cidade = new Cidade
            //                {
            //                    CidadeId = 1,
            //                    Nome = "São José do Rio Preto",
            //                    EstadoId = "SP"
            //                },
            //            },
            //            Celular = new Contato
            //            {
            //                ContatoId = 1,
            //                Descricao = "17992637301",
            //                TipoContatoId = Entity.Enum.EnumTipoContato.Celular
            //            },
            //            Email = new Contato
            //            {
            //                ContatoId = 2,
            //                Descricao = "alastor@gmail.com",
            //                TipoContatoId = Entity.Enum.EnumTipoContato.Email
            //            },
            //            CPF = new Documento
            //            {
            //                DocumentoId = 1,
            //                NumeroDocumento = "11",
            //                TipoDocumentoId = Entity.Enum.EnumTipoDocumento.CPF
            //            },
            //            RG = new Documento
            //            {
            //                DocumentoId = 2,
            //                NumeroDocumento = "22",
            //                TipoDocumentoId = Entity.Enum.EnumTipoDocumento.RG
            //            },
            //            Idiomas = new List<PessoaIdioma>
            //            {
            //                new PessoaIdioma
            //                {
            //                    IdiomaId = Entity.Enum.EnumIdioma.Portugues
            //                }
            //            }
            //        }
            //    );

            //entity.HasMany(d => d.Idiomas)
            //    .WithOne(d => d.Pessoa);
        }
    }

}
