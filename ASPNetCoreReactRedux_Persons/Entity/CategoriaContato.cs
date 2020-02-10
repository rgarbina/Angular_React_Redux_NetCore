using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class CategoriaContato
    {
        public EnumCategoriaContato CategoriaContatoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
