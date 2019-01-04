namespace Ingresso.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ingresso.Domain;

    public interface ISessaoRepository
    {
        Task<IEnumerable<Sessao>> GetAllSessoesAsync();

        Task<Sessao> GetSessaoAsync(string id);

        Task AddSessaoAsync(Sessao sala);

        Task<bool> RemoveSessaoAsync(string id);

        Task<bool> UpdateSessaoAsync(string id, Sessao item);
    }
}