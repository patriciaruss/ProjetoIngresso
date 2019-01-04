

namespace Ingresso.Api.Controllers
{
    using global::Application.DTO;
    using Ingresso.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            this.filmeService = filmeService;
        }

        // GET: api/Filme
        [HttpGet]
        public async Task<IEnumerable<FilmeDTO>> Get()
        {
            return await filmeService.GetAllAsync().ConfigureAwait(false);
        }

        // GET: api/Filme/5
        [HttpGet("{id}", Name = "GetFilme")]
        public async Task<ActionResult<FilmeDTO>> Get(string id)
        {
            var filme = await filmeService.GetFilmeByIdAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // POST: api/Filme
        [HttpPost]
        public async Task<ActionResult<FilmeDTO>> PostAsync([FromBody] FilmeDTO filme)
        {
            var createdFilme = await filmeService.CreateAsync(filme);

            return CreatedAtRoute("GetFilme", new { createdFilme.Id }, createdFilme);
        }

        // PUT: api/Filme/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] FilmeDTO filmeToUpdate)
        {
            var filme = await filmeService.GetFilmeByIdAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            await filmeService.UpdateAsync(id, filmeToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var filme = await filmeService.GetFilmeByIdAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            await filmeService.RemoveAsync(id);

            return NoContent();
        }
    }
}
