namespace Ingresso.Data
{
    using Ingresso.Domain;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Filme> Filmes
        {
            get
            {
                return _database.GetCollection<Filme>("Filmes");
            }
        }

        public IMongoCollection<Sala> Salas
        {
            get
            {
                return _database.GetCollection<Sala>("Salas");
            }
        }

        public IMongoCollection<Sessao> Sessoes
        {
            get
            {
                return _database.GetCollection<Sessao>("Sessoes");
            }
        }
    }
}
