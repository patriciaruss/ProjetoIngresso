using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaDTO>> GetAllAsync();

        Task<SalaDTO> GetSalaByIdAsync(string Id);

        Task<SalaDTO> CreateAsync(SalaDTO salaDto);

        Task<bool> UpdateAsync(string Id, SalaDTO salaDto);

        Task<bool> RemoveAsync(string Id);
    }
}