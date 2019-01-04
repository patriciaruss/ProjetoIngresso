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

    public class FilmeRepository : BaseRepository, IFilmeRepository
    {
        public FilmeRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {

        }

        public async Task<IEnumerable<Filme>> GetAllFilmesAsync()
        {
            try
            {
                return await _context.Filmes
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Filme> GetFilmeAsync(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Filmes
                                .Find(filme => filme.Id == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddFilmeAsync(Filme filme)
        {
            try
            {
                await _context.Filmes.InsertOneAsync(filme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveFilmeAsync(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Filmes.DeleteOneAsync(
                        Builders<Filme>.Filter.Eq("Id", GetInternalId(id)));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateFilmeAsync(string id, Filme filme)
        {
            try
            {
                 ReplaceOneResult actionResult
                    = await _context.Filmes
                                    .ReplaceOneAsync(n => n.Id == GetInternalId(id)
                                            , filme
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
