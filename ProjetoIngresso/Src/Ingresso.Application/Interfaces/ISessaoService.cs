using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface ISessaoService
    {
        Task<IEnumerable<SessaoDTO>> GetAllAsync();

        Task<SessaoDTO> GetSessaoByIdAsync(string Id);

        Task<SessaoDTO> CreateAsync(SessaoDTO sessaoDto);

        Task<bool> UpdateAsync(string Id, SessaoDTO sessaoDto);

        Task<bool> RemoveAsync(string Id);
    }
}
