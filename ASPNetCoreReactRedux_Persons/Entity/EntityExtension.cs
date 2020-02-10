using ASPNetCoreReactRedux_Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public static class DTOExtension
    {
        public static PessoaDTO ToDTO(this Pessoa pessoa)
        {
            return new PessoaDTO
            {
                PessoaId = pessoa.PessoaId,
                Ativado = pessoa.Ativado,
                Nome = pessoa.Nome,
                SobreNome = pessoa.SobreNome,
                Pseudonimo = pessoa.Pseudonimo,
                Sexo = pessoa.Sexo == true ? "Masculino" : "Feminino",
                DataNascimento = pessoa.DataNascimento,
                DataObito = pessoa.DataObito,
                Celular = pessoa.Celular.Descricao,
                Email = pessoa.Email.Descricao,
                CPF = pessoa.Documentos.FirstOrDefault(f => f.TipoDocumentoId == Enum.EnumTipoDocumento.CPF)?.NumeroDocumento,
                RG = pessoa.Documentos.FirstOrDefault(f => f.TipoDocumentoId == Enum.EnumTipoDocumento.RG)?.NumeroDocumento,
                Endereco = pessoa.Endereco.ToDTO(),
                Documentos = pessoa.Documentos.ToListDTO(),
                Idiomas = pessoa.Idiomas.ToListDTO()
            };
        }
        public static EnderecoDTO ToDTO(this Endereco endereco)
        {
            return new EnderecoDTO
            {
                EnderecoId = endereco.EnderecoId,
                TipoEnderecoId = (int)endereco.TipoEnderecoId,
                EstadoId = endereco.Cidade.EstadoId,
                CidadeId = endereco.Cidade.CidadeId,
                TipoEndereco = endereco.TipoEndereco.Descricao,
                Estado = endereco.Cidade.Estado.Nome,
                Cidade = endereco.Cidade.Nome,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Bairro = endereco.Bairro,
                Cep = endereco.CEP,
                Complemento = endereco.Complemento
            };
        }
        public static DocumentoDTO ToDTO(this Documento documento)
        {
            return new DocumentoDTO
            {
                DocumentoId = documento.DocumentoId,
                Documento = documento.NumeroDocumento,
                TipoDocumentoId = (int)documento.TipoDocumentoId,
                TipoDocumento = documento.TipoDocumento?.Documento
            };
        }
        public static IdiomaDTO ToDTO(this PessoaIdioma idioma)
        {
            return new IdiomaDTO
            {
                IdIdioma = (int)idioma.IdiomaId,
                Idioma = idioma.Idioma.LinguaIdioma
            };
        }
        public static RelacionamentoDTO ToDTO(this Relacionamento relacionamento)
        {
            return new RelacionamentoDTO
            {
                PessoaRelacionadaId = relacionamento.PessoaRelacionadaId,
                TipoRelacionamento = (int)relacionamento.TipoRelacionamentoId,
                Relacionamento = relacionamento.TipoRelacionamento?.Descricao
            };
        }

        public static List<DocumentoDTO> ToListDTO(this ICollection<Documento> listaDocumento)
        {
            return listaDocumento.Select(documento => documento.ToDTO()).ToList();
        }
        public static List<IdiomaDTO> ToListDTO(this ICollection<PessoaIdioma> listaIdioma)
        {
            return listaIdioma.Select(idioma => idioma.ToDTO()).ToList();
        }
        public static List<RelacionamentoDTO> ToListDTO(this ICollection<Relacionamento> listaRelacionamento)
        {
            return listaRelacionamento.Select(relacionamento => relacionamento.ToDTO()).ToList();
        }
        public static List<PessoaDTO> ToListDTO(this List<Pessoa> listaPessoa)
        {
            return listaPessoa.Select(pessoa => pessoa.ToDTO()).ToList();
        }

        public static List<EnderecoDTO> ToListDTO(this ICollection<Endereco> listaEndereco)
        {
            return listaEndereco.Select(endereco => endereco.ToDTO()).ToList();
        }
    }
}
