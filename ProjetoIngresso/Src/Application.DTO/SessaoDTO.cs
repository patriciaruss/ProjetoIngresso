using System;

namespace Application.DTO
{
    public class SessaoDTO
    {
        public DateTime Data { get; set; }

        public int QtLugar { get; set; }

        public decimal Valor { get; set; }

        public string Id { get; set; }

        public string FilmeId { get; set; }

        public string SalaId { get; set; }
    }
}