using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Estado
    {
        public string UF { get; set; }
        public string Nome { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}
