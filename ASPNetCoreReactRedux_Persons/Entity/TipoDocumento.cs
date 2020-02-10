using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class TipoDocumento 
    {
        public EnumTipoDocumento TipoDocumentoId { get; set; }
        public string Documento { get; set; }
    }
}
