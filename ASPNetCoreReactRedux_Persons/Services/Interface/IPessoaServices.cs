using ASPNetCoreReactRedux_Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Services
{
    public interface IPessoaServices
    {
        Task<List<PessoaDTO>> GetPessoasAsync();
        Task<PessoaDTO> GetPessoaAsync(long id);
        Task<PessoaDTO> InsertPessoaAsync(PessoaDTO pessoa);
        Task<bool> UpdatePessoaAsync(PessoaDTO pessoa);
        Task<bool> DeletePessoaAsync(long id);
        Task<bool> DeletePessosAsync(long[] id);
    }
}
