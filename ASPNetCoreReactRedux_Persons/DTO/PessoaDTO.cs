using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.DTO
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {
            Endereco = new EnderecoDTO();
            Documentos = new List<DocumentoDTO>();
            Idiomas = new List<IdiomaDTO>();
            Relacionamentos = new List<RelacionamentoDTO>();
        }
        public long PessoaId { get; set; }
        public bool Ativado { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Pseudonimo { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataObito { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        public EnderecoDTO Endereco { get; set; }

        public List<DocumentoDTO> Documentos { get; set; }
        public List<IdiomaDTO> Idiomas { get; set; }
        public List<RelacionamentoDTO> Relacionamentos { get; set; }
    }
}
