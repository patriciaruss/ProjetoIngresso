namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using System.Collections.Generic;

    public static class FilmeExtention
    {
        public static FilmeDTO MapToDto(this Filme filme)
        {
            if (filme == null)
            {
                return null;
            }

            return new FilmeDTO
            {
                Id = filme.Id.ToString(),
                Titulo = filme.Titulo,
                Lancamento = filme.Lancamento,
                QtDiasExibicao = filme.QtDiasExibicao,
                Descricao = filme.Descricao,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Atores = MapAtoresToDto(filme.Atores),
            };
        }

        private static IEnumerable<AtorDto> MapAtoresToDto(IEnumerable<Ator> atores)
        {
            if (atores == null)
            {
                yield break;
            }

            foreach (var item in atores)
            {
                yield return new AtorDto
                {
                    Nome = item.Nome,
                    Sexo = item.Sexo,
                };
            }
        }

        public static Filme MapToModel(this FilmeDTO filme)
        {
            var f = new Filme
            {
                Titulo = filme.Titulo,
                Lancamento = filme.Lancamento,
                QtDiasExibicao = filme.QtDiasExibicao,
                Descricao = filme.Descricao,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
                Atores = MapAtoresToModel(filme.Atores),
            };
            return f;
        }

        private static IEnumerable<Ator> MapAtoresToModel(IEnumerable<AtorDto> atores)
        {
            if (atores == null)
            {
                yield break;
            }

            foreach (var item in atores)
            {
                yield return new Ator
                {
                    Nome = item.Nome,
                    Sexo = item.Sexo,
                };
            }
        }

        public static Filme MapToNewValues(this Filme currentValue, FilmeDTO newValue)
        {
            currentValue.Titulo = currentValue.Titulo;
            currentValue.Lancamento = currentValue.Lancamento;
            currentValue.QtDiasExibicao = currentValue.QtDiasExibicao;
            currentValue.Descricao = currentValue.Descricao;
            currentValue.Genero = currentValue.Genero;
            currentValue.Diretor = currentValue.Diretor;
            currentValue.Atores = MapAtoresToModel(newValue.Atores);
            return currentValue;
        }
    }
}
