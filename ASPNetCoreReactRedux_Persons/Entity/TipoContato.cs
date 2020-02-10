using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class TipoContato
    {
        public EnumTipoContato TipoContatoId { get; set; }
        public string Descricao { get; set; }
    }
}
