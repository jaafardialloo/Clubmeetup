using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MongoDB.Database.Models
{
    public class Administration : IAdministration
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Num_tel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        

        public Administration(string nom, string prenom, string num_tel, string email, string password, string description)
        {
            Nom = nom;
            Prenom = prenom;
            Num_tel = num_tel;
            Email = email;
            Password = password;
            Description = description;
            
        }
    }
}
