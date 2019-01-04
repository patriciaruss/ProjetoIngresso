using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDTO>> GetAllAsync();

        Task<FilmeDTO> GetFilmeByIdAsync(string Id);

        Task<FilmeDTO> CreateAsync(FilmeDTO filmeDto);

        Task<bool> UpdateAsync(string Id, FilmeDTO filmeDto);

        Task<bool> RemoveAsync(string Id);
    }
}