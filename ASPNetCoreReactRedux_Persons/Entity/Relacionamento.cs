using ASPNetCoreReactRedux_Persons.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Entity
{
    public class Relacionamento
    {

        public long PessoaPropriaId { get; set; }
        public long PessoaRelacionadaId { get; set; }
        public EnumTipoRelacionamento TipoRelacionamentoId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Pessoa Relacionado { get; set; }
        public virtual TipoRelacionamento TipoRelacionamento { get; set; }
    }
}
