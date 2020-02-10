using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.DTO
{
    public class DocumentoDTO
    {
        public long DocumentoId { get; set; }
        public string Documento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string TipoDocumento { get; set; }
    }
}
