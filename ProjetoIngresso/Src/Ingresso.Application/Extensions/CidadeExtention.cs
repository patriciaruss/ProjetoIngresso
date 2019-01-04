namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;

    public static class CidadeExtention
    {
        public static CidadeDTO MapToDto(this Cidade cidade)
        {
            if (cidade == null)
            {
                return null;
            }

            return new CidadeDTO
            {
                Id = cidade.Id.ToString(),
                Nome = cidade.Nome
            };
        }


        public static Cidade MapToModel(this CidadeDTO cidade, bool setId = false)
        {
            var f = new Cidade
            {
                Nome = cidade.Nome,
                 UF = cidade.UF
            };

            if (setId)
            {
                f.Id = new ObjectId(cidade.Id);
            }

            return f;
        }
    }
}
