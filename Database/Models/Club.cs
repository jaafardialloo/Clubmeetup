using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MongoDB.Database.Models
{
    public class Club : IClub
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public List<Evenement> Evenements { get; set; } = new List<Evenement>();

        public Club(string name, string email, string password, string description)
        {
            Name = name;
            Email = email;
            Password = password;
            Description = description;
        }
    }
}
