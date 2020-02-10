using ASPNetCoreReactRedux_Persons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Repository
{
    public interface IPessoaRepository : IDataRepository<Pessoa>, IDisposable
    {
        Task<List<Pessoa>> GetPessoasAsync();
        Task<Pessoa> GetPessoaAsync(long id);
        Task<List<Pessoa>> GetPessoasAsync(long[] id);
    }
}
