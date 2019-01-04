namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;

    public static class CinemaExtention
    {
        public static CinemaDTO MapToDto(this Cinema cinema)
        {
            if (cinema == null)
            {
                return null;
            }

            return new CinemaDTO
            {
                Id = cinema.Id.ToString(),
                Nome = cinema.Nome,
                Cidade = cinema.Cidade
            };
        }


        public static Cinema MapToModel(this CinemaDTO cinema, bool setId = false)
        {
            var f = new Cinema
            {
                Nome = cinema.Nome, 
                Cidade = cinema.Cidade
            };

            if (setId)
            {
                f.Id = new ObjectId(cinema.Id);
            }

            return f;
        }
    }
}
