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
    [Route("api/cinemas")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        // GET: api/Filme
        [HttpGet]
        public IEnumerable<CinemaDTO> Get()
        {
            return cinemaService.GetAll();
        }

        // GET: api/Filme/5
        [HttpGet("{id}", Name = "GetCinema")]
        public ActionResult<CinemaDTO> Get(string id)
        {
            var cinema = cinemaService.GetFilmeById(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return cinema;
        }

        // POST: api/Filme
        [HttpPost]
        public ActionResult<CinemaDTO> Post([FromBody] CinemaDTO cinema)
        {
            var createdcinema = cinemaService.Create(cinema);

            return CreatedAtRoute("Get", new { createdcinema.Id }, createdcinema);
        }

        // PUT: api/Filme/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] CinemaDTO cinemaToUpdate)
        {
            var cinema = cinemaService.GetFilmeById(id);

            if (cinema == null)
            {
                return NotFound();
            }

            cinemaService.Update(id, cinemaToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var cinema = cinemaService.GetFilmeById(id);

            if (cinema == null)
            {
                return NotFound();
            }

            cinemaService.Remove(id);

            return NoContent();
        }
    }
}
