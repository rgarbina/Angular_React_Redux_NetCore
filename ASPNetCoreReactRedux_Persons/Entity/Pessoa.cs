using ASPNetCoreReactRedux_Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Pessoa : ModeloBase
    {
        public Pessoa()
        {
            Ativado = true;
        }

        public long PessoaId { get; set; }
        public bool Ativado { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Pseudonimo { get; set; }
        public bool Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataObito { get; set; }
        public long EnderecoId { get; set; }
        public long CelularId { get; set; }
        public long EmailId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Contato Celular { get; set; }
        public virtual Contato Email { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<PessoaIdioma> Idiomas { get; set; }
        public virtual ICollection<Relacionamento> Relacionamentos { get; set; }
    }
}
