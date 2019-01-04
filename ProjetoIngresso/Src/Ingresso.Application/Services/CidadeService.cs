namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Domain;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class CidadeService : BaseService, ICidadeService
    {
        private readonly IMongoCollection<Cidade> cidadeRepository;

        public CidadeService(IConfiguration config) : base(config)
        {
            cidadeRepository = base.DataBase.GetCollection<Cidade>("Cidades");
        }

        public IEnumerable<CidadeDTO> GetAll()
        {
            var result = cidadeRepository.Find(filter => true).ToEnumerable();

            foreach (var item in result)
            {
                yield return item.MapToDto();
            }
        }

        public CidadeDTO GetFilmeById(string Id)
        {
            var docId = new ObjectId(Id);

            var result = cidadeRepository.Find(f => f.Id == docId).FirstOrDefault();

            return result.MapToDto();
        }

        public CidadeDTO Create(CidadeDTO cidadeDto)
        {
            var cidade = cidadeDto.MapToModel();

            cidadeRepository.InsertOne(cidade);

            return cidade.MapToDto();
        }

        public void Update(string Id, CidadeDTO cidadeDto)
        {
            var cidade = cidadeDto.MapToModel(true);

            cidadeRepository.ReplaceOne(f => f.Id == cidade.Id, cidade);
        }

        public void Remove(string Id)
        {
            cidadeRepository.DeleteOne(f => f.Id == new ObjectId(Id));
        }
    }
}
