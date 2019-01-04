namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Data.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }

        public async Task<IEnumerable<FilmeDTO>> GetAllAsync()
        {
            var result = await filmeRepository.GetAllFilmesAsync().ConfigureAwait(false);

            var mappedFilmes = new List<FilmeDTO>();

            foreach (var item in result)
            {
                mappedFilmes.Add(item.MapToDto());
            }

            return mappedFilmes;
        }

        public async Task<FilmeDTO> GetFilmeByIdAsync(string Id)
        {
            var result = await filmeRepository.GetFilmeAsync(Id);

            return result.MapToDto();
        }

        public async Task<FilmeDTO> CreateAsync(FilmeDTO filmeDto)
        {
            var filme = filmeDto.MapToModel();

            await filmeRepository.AddFilmeAsync(filme);

            return filme.MapToDto();
        }

        public async Task<bool> UpdateAsync(string Id, FilmeDTO filmeDto)
        {
            var currentFilme = await filmeRepository.GetFilmeAsync(Id);

            currentFilme.MapToNewValues(filmeDto);

            return await filmeRepository.UpdateFilmeAsync(Id, currentFilme);
        }

        public async Task<bool> RemoveAsync(string Id)
        {
            return await filmeRepository.RemoveFilmeAsync(Id);
        }
    }
}
