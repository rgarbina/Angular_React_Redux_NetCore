using ASPNetCoreReactRedux_Persons.DTO;
using ASPNetCoreReactRedux_Persons.Entity;
using ASPNetCoreReactRedux_Persons.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServices _pessoaService;

        public PessoaController(IPessoaServices pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: api/Pessoa
        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            return Ok(await _pessoaService.GetPessoasAsync());
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoa([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Produto = await _pessoaService.GetPessoaAsync(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Ok(Produto);
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa([FromRoute] long id, [FromBody] PessoaDTO pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.PessoaId)
            {
                return BadRequest();
            }
            bool exist = false;
            try
            {
                exist = await _pessoaService.UpdatePessoaAsync(pessoa);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!exist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pessoa
        [HttpPost]
        public async Task<IActionResult> PostPessoa([FromBody] PessoaDTO pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pessoa.PessoaId = 0;
            pessoa = await _pessoaService.InsertPessoaAsync(pessoa);

            if (pessoa.PessoaId == 0)
            {
                return BadRequest();
            }

            return StatusCode(201, new { produtoResponse = pessoa });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> PostDeletePessoa([FromBody] long[] id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool exist = false;

            exist = await _pessoaService.DeletePessosAsync(id);
            if (!exist)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/Pessoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool exist = false;

            exist = await _pessoaService.DeletePessoaAsync(id);
            if (!exist)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}