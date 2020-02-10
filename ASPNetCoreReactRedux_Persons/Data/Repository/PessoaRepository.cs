using ASPNetCoreReactRedux_Persons.Data.Context;
using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Data.Repository
{
    public class PessoaRepository : DataRepository<Pessoa>, IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            return await BuscarPessoa().OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Pessoa> GetPessoaAsync(long id)
        {
            return await BuscarPessoa().FirstOrDefaultAsync(f => f.PessoaId == id);
        }

        public async Task<List<Pessoa>> GetPessoasAsync(long[] id)
        {
            return await BuscarPessoa().Where(f => id.Contains(f.PessoaId)).ToListAsync();
        }

        private IQueryable<Pessoa> BuscarPessoa()
        {
            return _context.Pessoas
                 .Include(i => i.Endereco)
                    .ThenInclude(i => i.TipoEndereco)
                .Include(i => i.Endereco)
                    .ThenInclude(i => i.Cidade)
                        .ThenInclude(i => i.Estado)
                .Include(i => i.Celular)
                .Include(i => i.Email)
                .Include(i => i.Documentos)
                    .ThenInclude(i => i.TipoDocumento)
                .Include(i => i.Idiomas)
                    .ThenInclude(i => i.Idioma)
                .Include(i => i.Relacionamentos)
                    .ThenInclude(i => i.TipoRelacionamento)
                .Where(w => w.Ativado);
        }
    }
}
