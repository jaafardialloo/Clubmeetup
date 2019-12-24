//sponsor entity Dj
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace MongoDB.Database.Models
{
    public class Sponsor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string prenom { get; set; }
        public string Add_email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string num_tel { get; set; }
        public DateTime date_inscrit { get; set; }
        

    }
}