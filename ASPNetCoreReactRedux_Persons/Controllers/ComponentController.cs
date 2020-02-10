using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreReactRedux_Persons.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreReactRedux_Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        // GET: api/Component/Cidades
        [HttpGet("Cidades/{uf?}")]
        public async Task<IActionResult> GetCidades(string uf = "")
        {
            uf = uf == "undefined" ? "" : uf;
            return Ok(await _componentService.GetCidadesAsync(uf));
        }

        [HttpGet("Pessoas")]
        public async Task<IActionResult> GetPessoas()
        {
            return Ok(await _componentService.GetPessoasAsync());
        }
        [HttpGet("Linguas")]
        public async Task<IActionResult> GetLinguas()
        {
            return Ok(await _componentService.GetLinguasAsync());
        }
        [HttpGet("Estados")]
        public async Task<IActionResult> GetEstados()
        {
            return Ok(await _componentService.GetEstadosAsync());
        }
    }
}
