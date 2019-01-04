using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Ingresso.Data.Repositories
{
    public class BaseRepository
    {
        private readonly IOptions<MongoDbSettings> settings;
        protected readonly DbContext _context = null;

        public BaseRepository(IOptions<MongoDbSettings> settings)
        {
            this.settings = settings;
            _context = new DbContext(settings);
        }

        protected ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}