using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class PessoaIdioma
    {
        public long PessoaId { get; set; }
        public EnumIdioma IdiomaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Idioma Idioma { get; set; }
    }
}
