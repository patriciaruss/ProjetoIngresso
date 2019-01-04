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

    public class SalaRepository : BaseRepository, ISalaRepository
    {
        public SalaRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {

        }

        public async Task<IEnumerable<Sala>> GetAllSalasAsync()
        {
            try
            {
                return await _context.Salas
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sala> GetSalaAsync(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Salas
                                .Find(Sala => Sala.Id == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddSalaAsync(Sala Sala)
        {
            try
            {
                await _context.Salas.InsertOneAsync(Sala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveSalaAsync(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Salas.DeleteOneAsync(
                        Builders<Sala>.Filter.Eq("Id", GetInternalId(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateSalaAsync(string id, Sala Sala)
        {
            try
            {
                ReplaceOneResult actionResult
                   = await _context.Salas
                                   .ReplaceOneAsync(n => n.Id == GetInternalId(id)
                                           , Sala
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
