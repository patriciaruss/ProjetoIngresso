using Application.DTO; 
using System.Collections.Generic; 

namespace Ingresso.Application.Interfaces
{
    public interface ICidadeService
    {
        IEnumerable<CidadeDTO> GetAll();

        CidadeDTO GetFilmeById(string Id);

        CidadeDTO Create(CidadeDTO cidadeDto);

        void Update(string Id, CidadeDTO cidadeDto);

        void Remove(string Id);
    }
}
