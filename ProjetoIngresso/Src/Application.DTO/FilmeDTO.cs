namespace Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class FilmeDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Lancamento { get; set; }

        public int QtDiasExibicao { get; set; }

        public string Diretor { get; set; }

        public string Genero { get; set; }

        public IEnumerable<AtorDto> Atores { get; set; }

        public string Id { get; set; }
    }
}
