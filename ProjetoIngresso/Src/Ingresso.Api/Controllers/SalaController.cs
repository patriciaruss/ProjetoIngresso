using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Ingresso.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService salaService;

        public SalaController(ISalaService salaService)
        {
            this.salaService = salaService;
        }

        // GET: api/sala
        [HttpGet]
        public async Task<IEnumerable<SalaDTO>> Get()
        {
            return await salaService.GetAllAsync().ConfigureAwait(false);
        }

        // GET: api/sala/5
        [HttpGet("{id}", Name = "GetSala")]
        public async Task<ActionResult<SalaDTO>> Get(string id)
        {
            var sessao = await salaService.GetSalaByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return sessao;
        }

        // POST: api/sala
        [HttpPost]
        public async Task<ActionResult<SalaDTO>> PostAsync([FromBody] SalaDTO sala)
        {
            var createdsala = await salaService.CreateAsync(sala);

            return CreatedAtRoute("GetSala", new { createdsala.Id }, createdsala);
        }

        // PUT: api/sala/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] SalaDTO salaToUpdate)
        {
            var sala = await salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            await salaService.UpdateAsync(id, salaToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var sala = await salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            await salaService.RemoveAsync(id);

            return NoContent();
        }
    }
}
