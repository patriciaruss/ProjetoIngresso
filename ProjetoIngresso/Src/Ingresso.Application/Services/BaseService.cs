
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ingresso.Application.Services
{
    public class BaseService
    {
        private IConfiguration config;
        
        public IMongoDatabase DataBase { get; set; }

        public BaseService(IConfiguration config)
        {
            this.config = config;
            var client = new MongoClient(config.GetConnectionString("IngressoDb"));
            DataBase = client.GetDatabase("IngressoDb");
        }
    }
}