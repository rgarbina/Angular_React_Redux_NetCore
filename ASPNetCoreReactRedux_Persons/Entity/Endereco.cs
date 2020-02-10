using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Endereco
    {
        public long EnderecoId { get; set; }
        public string CEP { get; set; }
        public EnumTipoEndereco TipoEnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public long CidadeId { get; set; }

        public Cidade Cidade { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
    }
}
