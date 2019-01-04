namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;

    public static class SessaoExtention
    {
        public static SessaoDTO MapToDto(this Sessao sessao)
        {
            if (sessao == null)
            {
                return null;
            }

            return new SessaoDTO
            {                
                Id = sessao.Id.ToString(),
                Data = sessao.Data,
                QtLugar = sessao.QtLugar,
                Valor = sessao.Valor,
                FilmeId = sessao.FilmeId?.Id.ToString(),
                SalaId = sessao.SalaId?.Id.ToString(),
            };
        }


        public static Sessao MapToModel(this SessaoDTO sessao, bool setId = false)
        {
            var f = new Sessao
            {
                Data = sessao.Data,
                QtLugar = sessao.QtLugar,
                Valor = sessao.Valor,
            };

            if (setId)
            {
                f.Id = new ObjectId(sessao.Id);
            }

            return f;
        }

        public static Sessao MapToNewValues(this Sessao currentValue, SessaoDTO newValue)
        {
            currentValue.Data = newValue.Data;
            currentValue.QtLugar = newValue.QtLugar;
            currentValue.Valor = newValue.Valor;
            return currentValue;
        }
    }
}
