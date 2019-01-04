namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;

    public static class SalaExtention
    {
        public static SalaDTO MapToDto(this Sala sala)
        {
            if (sala == null)
            {
                return null;
            }

            return new SalaDTO
            {
                Id = sala.Id.ToString(),
                Nome = sala.Nome,
                Cinema = sala.Cinema,
                Cidade = sala.Cidade,
            };
        }


        public static Sala MapToModel(this SalaDTO sala, bool setId = false)
        {
            var f = new Sala
            {
                Nome = sala.Nome,
                Cinema = sala.Cinema,
                Cidade = sala.Cidade
            };

            if (setId)
            {
                f.Id = new ObjectId(sala.Id);
            }

            return f;
        }

        public static Sala MapToNewValues(this Sala currentValue, SalaDTO newValue)
        {
            currentValue.Nome = newValue.Nome;
            currentValue.Cinema = newValue.Cinema;
            currentValue.Cidade = newValue.Cidade;

            return currentValue;
        }
    }
}
