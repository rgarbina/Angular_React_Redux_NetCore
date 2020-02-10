using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Documento
    {
        public long DocumentoId { get; set; }
        public long PessoaId { get; set; }
        public EnumTipoDocumento TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
