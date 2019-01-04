namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Data.Interfaces;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SessaoService : ISessaoService
    {
        private readonly ISessaoRepository sessaoRepository;

        private readonly IFilmeRepository filmeRepository;

        private readonly ISalaRepository salaRepository;


        public SessaoService(ISessaoRepository sessaoRepository, IFilmeRepository filmeRepository, ISalaRepository salaRepository)
        {
            this.sessaoRepository = sessaoRepository;
            this.filmeRepository = filmeRepository;
            this.salaRepository = salaRepository;
        }

        public async Task<IEnumerable<SessaoDTO>> GetAllAsync()
        {
            var result = await sessaoRepository.GetAllSessoesAsync().ConfigureAwait(false);

            var mappedFilmes = new List<SessaoDTO>();

            foreach (var item in result)
            {
                mappedFilmes.Add(item.MapToDto());
            }

            return mappedFilmes;
        }

        public async Task<SessaoDTO> GetSessaoByIdAsync(string Id)
        {
            var result = await sessaoRepository.GetSessaoAsync(Id);

            return result.MapToDto();
        }

        public async Task<SessaoDTO> CreateAsync(SessaoDTO SessaoDTO)
        {
            var sessao = SessaoDTO.MapToModel();

            var filme = await filmeRepository.GetFilmeAsync(SessaoDTO.FilmeId).ConfigureAwait(false);

            var sala = await salaRepository.GetSalaAsync(SessaoDTO.SalaId).ConfigureAwait(false);

            sessao.FilmeId = new MongoDBRef("Filme", filme.Id);

            sessao.SalaId = new MongoDBRef("Sala", sala.Id);

            await sessaoRepository.AddSessaoAsync(sessao);

            return sessao.MapToDto();
        }

        public async Task<bool> UpdateAsync(string Id, SessaoDTO SessaoDTO)
        {
            var currentSessao = await sessaoRepository.GetSessaoAsync(Id);

            currentSessao.MapToNewValues(SessaoDTO);

            var filme = await filmeRepository.GetFilmeAsync(SessaoDTO.FilmeId).ConfigureAwait(false);

            var sala = await salaRepository.GetSalaAsync(SessaoDTO.SalaId).ConfigureAwait(false);

            currentSessao.FilmeId = new MongoDBRef("Filme", filme.Id);

            currentSessao.SalaId = new MongoDBRef("Sala", sala.Id);

            return await sessaoRepository.UpdateSessaoAsync(Id, currentSessao);
        }

        public async Task<bool> RemoveAsync(string Id)
        {
            return await sessaoRepository.RemoveSessaoAsync(Id);
        }
    }
}
