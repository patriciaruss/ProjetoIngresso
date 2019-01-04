namespace Ingresso.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ingresso.Domain;

    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> GetAllSalasAsync();

        Task<Sala> GetSalaAsync(string id);

        Task AddSalaAsync(Sala sala);

        Task<bool> RemoveSalaAsync(string id);

        Task<bool> UpdateSalaAsync(string id, Sala item);
    }
}