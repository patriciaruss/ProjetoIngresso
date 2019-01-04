namespace Ingresso.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ingresso.Domain;

    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetAllFilmesAsync();

        Task<Filme> GetFilmeAsync(string id);

        Task AddFilmeAsync(Filme filme);

        Task<bool> RemoveFilmeAsync(string id);

        Task<bool> UpdateFilmeAsync(string id, Filme item);
    }
}