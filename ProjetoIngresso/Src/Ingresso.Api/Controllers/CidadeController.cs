using System.Collections.Generic;
using Application.DTO;
using Ingresso.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [Route("api/cidades")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            this.cidadeService = cidadeService;
        }

        // GET: api/Filme
        [HttpGet]
        public IEnumerable<CidadeDTO> Get()
        {
            return cidadeService.GetAll();
        }

        // GET: api/Filme/5
        [HttpGet("{id}", Name = "GetCidade")]
        public ActionResult<CidadeDTO> Get(string id)
        {
            var cidade = cidadeService.GetFilmeById(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // POST: api/Filme
        [HttpPost]
        public ActionResult<CidadeDTO> Post([FromBody] CidadeDTO cidade)
        {
            var createdCidade = cidadeService.Create(cidade);

            return CreatedAtRoute("Get", new { createdCidade.Id }, createdCidade);
        }

        // PUT: api/Filme/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] CidadeDTO cidadeToUpdate)
        {
            var cidade = cidadeService.GetFilmeById(id);

            if (cidade == null)
            {
                return NotFound();
            }

            cidadeService.Update(id, cidadeToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var cidade = cidadeService.GetFilmeById(id);

            if (cidade == null)
            {
                return NotFound();
            }

            cidadeService.Remove(id);

            return NoContent();
        }
    }
}
