namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Domain;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class CinemaService : BaseService, ICinemaService
    {
        private readonly IMongoCollection<Cinema> cinemaRepository;

        public CinemaService(IConfiguration config) : base(config)
        {
            cinemaRepository = base.DataBase.GetCollection<Cinema>("Cinemas");
        }

        public IEnumerable<CinemaDTO> GetAll()
        {
            var result = cinemaRepository.Find(filter => true).ToEnumerable();

            foreach (var item in result)
            {
                yield return item.MapToDto();
            }
        }

        public CinemaDTO GetFilmeById(string Id)
        {
            var docId = new ObjectId(Id);

            var result = cinemaRepository.Find(f => f.Id == docId).FirstOrDefault();

            return result.MapToDto();
        }

        public CinemaDTO Create(CinemaDTO cinemaDto)
        {
            var cinema = cinemaDto.MapToModel();

            cinemaRepository.InsertOne(cinema);

            return cinema.MapToDto();
        }

        public void Update(string Id, CinemaDTO cinemaDto)
        {
            var cinema = cinemaDto.MapToModel(true);

            cinemaRepository.ReplaceOne(f => f.Id == cinema.Id, cinema);
        }

        public void Remove(string Id)
        {
            cinemaRepository.DeleteOne(f => f.Id == new ObjectId(Id));
        }
    }
}
