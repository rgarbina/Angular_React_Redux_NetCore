using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Contato
    {
        public long ContatoId { get; set; }
        public string Descricao { get; set; }
        public EnumCategoriaContato CategoriaContatoId { get; set; }
        public EnumTipoContato TipoContatoId { get; set; }

        public virtual CategoriaContato CategoriaContato { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}
