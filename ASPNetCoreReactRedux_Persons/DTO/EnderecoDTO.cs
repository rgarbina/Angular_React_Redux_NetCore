using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.DTO
{
    public class EnderecoDTO
    {
        public long EnderecoId { get; set; }
        public int TipoEnderecoId { get; set; }
        public string EstadoId { get; set; }
        public long CidadeId { get; set; }
        public string TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
    }
}
