using Application.DTO;
using Ingresso.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Api.Controllers
{
    [Route("api/sessoes")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService sessaoService;

        private readonly IFilmeService filmeService;

        private readonly ISalaService salaService;


        public SessaoController(ISessaoService sessaoService, IFilmeService filmeService, ISalaService salaService)
        {
            this.sessaoService = sessaoService;
            this.filmeService = filmeService;
            this.salaService = salaService;
        }

        // GET: api/sessao
        [HttpGet]
        public async Task<IEnumerable<SessaoDTO>> Get()
        {
            return await sessaoService.GetAllAsync().ConfigureAwait(false);
        }

        // GET: api/sessao/5
        [HttpGet("{id}", Name = "GetSessao")]
        public async Task<ActionResult<SessaoDTO>> Get(string id)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return sessao;
        }

        // POST: api/sessao
        [HttpPost]
        public async Task<ActionResult<SessaoDTO>> PostAsync([FromBody] SessaoDTO sessao)
        {
            string message = "";

            message = await CheckRequiredFields(sessao).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(message))
            {
                return BadRequest(message);
            }

            var createdsessao = await sessaoService.CreateAsync(sessao);

            return CreatedAtRoute("GetSessao", new { createdsessao.Id }, createdsessao);
        }

        private async Task<string> CheckRequiredFields(SessaoDTO sessao)
        {
            var filme = await this.filmeService.GetFilmeByIdAsync(sessao.FilmeId).ConfigureAwait(false);

            if (filme == null)
            {
                return "O Identificador válido para o filme deverá ser informado.";
            }

            var sala = await this.salaService.GetSalaByIdAsync(sessao.SalaId).ConfigureAwait(false);

            if (sala == null)
            {
                return "O identificador válido para a sala deverá ser informado.";
            }

            return string.Empty;
        }

        // PUT: api/sessao/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] SessaoDTO sessaoToUpdate)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            string message = "";

            message = await CheckRequiredFields(sessao).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(message))
            {
                return BadRequest(message);
            }

            await sessaoService.UpdateAsync(id, sessaoToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            await sessaoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
