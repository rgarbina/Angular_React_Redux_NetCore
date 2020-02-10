using ASPNetCoreReactRedux_Persons.Data.Repository;
using ASPNetCoreReactRedux_Persons.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IDataRepository<Pessoa> _dataPessoaRepository;
        private readonly IDataRepository<Cidade> _dataCidadeRepository;
        private readonly IDataRepository<Estado> _dataEstadoRepository;
        private readonly IDataRepository<Idioma> _dataLinguaRepository;
        private readonly ILogger _logger;

        public ComponentService(ILoggerFactory loggerFactory, IDataRepository<Pessoa> dataPessoaRepository,
            IDataRepository<Cidade> dataCidadeRepository, IDataRepository<Estado> dataEstadoRepository, IDataRepository<Idioma> dataLinguaRepository)
        {
            _logger = loggerFactory.CreateLogger("ComponentService");
            _dataPessoaRepository = dataPessoaRepository;
            _dataCidadeRepository = dataCidadeRepository;
            _dataEstadoRepository = dataEstadoRepository;
            _dataLinguaRepository = dataLinguaRepository;
        }

        public async Task<List<SelectListItem>> GetPessoasAsync()
        {
            return await _dataPessoaRepository.GetAllAsNoTracking().Select(s => new SelectListItem
            {
                Text = s.Nome + " " + s.SobreNome,
                Value = s.PessoaId.ToString()
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetCidadesAsync(string uf)
        {
            var cidades = _dataCidadeRepository.GetAllAsNoTracking();
            if (!string.IsNullOrEmpty(uf))
            {
                cidades = cidades.Where(w => w.EstadoId.ToLower() == uf.ToLower());
            }

            return await cidades.Select(s => new SelectListItem
            {
                Text = s.Nome,
                Value = s.CidadeId.ToString()
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetEstadosAsync()
        {
            return await _dataEstadoRepository.GetAllAsNoTracking().Select(s => new SelectListItem
            {
                Text = s.Nome,
                Value = s.UF.ToString()
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetLinguasAsync()
        {
            return await _dataEstadoRepository.GetAllAsNoTracking().Select(s => new SelectListItem
            {
                Text = s.Nome,
                Value = s.UF.ToString()
            }).ToListAsync();
        }
    }
}
