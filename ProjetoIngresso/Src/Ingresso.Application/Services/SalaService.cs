namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Data.Interfaces;
    using Ingresso.Data.Repositories;
    using Ingresso.Domain;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SalaService : ISalaService
    {
        private readonly ISalaRepository salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            this.salaRepository = salaRepository;
        }

        public async Task<IEnumerable<SalaDTO>> GetAllAsync()
        {
            var result = await salaRepository.GetAllSalasAsync().ConfigureAwait(false);

            var mappedFilmes = new List<SalaDTO>();

            foreach (var item in result)
            {
                mappedFilmes.Add(item.MapToDto());
            }

            return mappedFilmes;
        }

        public async Task<SalaDTO> GetSalaByIdAsync(string Id)
        {
            var result = await salaRepository.GetSalaAsync(Id);

            return result.MapToDto();
        }

        public async Task<SalaDTO> CreateAsync(SalaDTO salaDto)
        {
            var sala = salaDto.MapToModel();

            await salaRepository.AddSalaAsync(sala);

            return sala.MapToDto();
        }

        public async Task<bool> UpdateAsync(string Id, SalaDTO salaDto)
        {
            var currentSala = await salaRepository.GetSalaAsync(Id);

            currentSala.MapToNewValues(salaDto);

            return await salaRepository.UpdateSalaAsync(Id, currentSala);
        }

        public async Task<bool> RemoveAsync(string Id)
        {
            return await salaRepository.RemoveSalaAsync(Id);
        }
    }
}
