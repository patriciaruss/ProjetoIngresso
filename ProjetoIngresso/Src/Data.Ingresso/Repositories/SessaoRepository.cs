namespace Ingresso.Data.Repositories
{
    using Ingresso.Data.Interfaces;
    using Ingresso.Domain;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SessaoRepository : BaseRepository, ISessaoRepository
    {
        public SessaoRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {

        }

        public async Task<IEnumerable<Sessao>> GetAllSessoesAsync()
        {
            try
            {
                return await _context.Sessoes
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sessao> GetSessaoAsync(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Sessoes
                                .Find(Sessao => Sessao.Id == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddSessaoAsync(Sessao sessao)
        {
            try
            {
                await _context.Sessoes.InsertOneAsync(sessao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveSessaoAsync(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Sessoes.DeleteOneAsync(
                        Builders<Sessao>.Filter.Eq("Id", GetInternalId(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateSessaoAsync(string id, Sessao sessao)
        {
            try
            {
                ReplaceOneResult actionResult
                   = await _context.Sessoes
                                   .ReplaceOneAsync(n => n.Id == GetInternalId(id)
                                           , sessao
                                           , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
