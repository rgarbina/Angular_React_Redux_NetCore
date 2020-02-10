using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.DTO
{
    public class RelacionamentoDTO
    {
        public long PessoaRelacionadaId { get; set; }
        public int TipoRelacionamento { get; set; }
        public string Relacionamento { get; set; }
    }
}
