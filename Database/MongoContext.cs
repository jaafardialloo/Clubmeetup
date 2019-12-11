using Microsoft.Extensions.Configuration;

using MongoDB.Database.Models;
using MongoDB.Driver;

namespace MongoDB.Database
{
    public class MongoContext : IMongoContext
    {
        private readonly IConfiguration _config;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration config)
        {
            _config = config;
            _client = new MongoClient(config["MongoDB:Connection"]);
            _database = _client.GetDatabase(config["MongoDB:Database"]);
        }

        public IMongoCollection<Club> Clubs
        {
            get
            {
                return _database.GetCollection<Club>("Clubs");
            }
        }

        public IMongoCollection<Ecole> Ecoles
        {
            get
            {
                return _database.GetCollection<Ecole>("Ecoles");
            }
        }

        public IMongoCollection<Universite> Universites
        {
            get
            {
                return _database.GetCollection<Universite>("Universites");
            }
        }
        public IMongoCollection<Administration> Administrations
        {
            get
            {
                return _database.GetCollection<Administration>("Administrations");
            }
        }
    }
}
