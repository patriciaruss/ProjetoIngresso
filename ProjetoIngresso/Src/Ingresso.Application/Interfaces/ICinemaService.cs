using Application.DTO;
using System.Collections.Generic;

namespace Ingresso.Application.Interfaces
{
    public interface ICinemaService
    {
        IEnumerable<CinemaDTO> GetAll();

        CinemaDTO GetFilmeById(string Id);

        CinemaDTO Create(CinemaDTO cinemaDto);

        void Update(string Id, CinemaDTO cinemaDto);

        void Remove(string Id);
    }
}
