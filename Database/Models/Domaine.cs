//Domaine Entity DJ
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MongoDB.Database.Models
{
    public class Domaine 
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        
    }
}
