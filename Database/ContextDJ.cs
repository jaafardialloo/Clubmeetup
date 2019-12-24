using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Database.Models;
 
namespace MongoDB.Database
{
    public class ClubMeetDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
 
        public ClubMeetDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("MongoDBNetCore");
        }
 
        public IMongoCollection<Evenement> EvenementRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Evenement>("EvenementRecord");
            }
        }
 
        /*/public IMongoCollection<Cities> CityRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Cities>("Cities");
            }
        }*/
    }
}