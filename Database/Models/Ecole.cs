using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MongoDB.Database.Models
{
    public class Ecole : IEcole
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public List<Club> Clubs { get; set; } = new List<Club>();
        public List<Administration> Administrations { get; set; } = new List<Administration>();
        
       
        public Ecole(string nom, string adresse,string description, string region)
        {
            Nom = nom;
            Adresse = adresse;
            Description = description;
            Region = region;
           
          
        }
    }
}