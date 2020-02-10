using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Cidade
    {
        public long CidadeId { get; set; }
        public string Nome { get; set; }
        public string EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
