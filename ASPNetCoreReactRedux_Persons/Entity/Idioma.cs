using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Idioma
    {
        public EnumIdioma IdiomaId { get; set; }
        public string LinguaIdioma { get; set; }

        public virtual ICollection<PessoaIdioma> Pessoas { get; set; }
    }
}
