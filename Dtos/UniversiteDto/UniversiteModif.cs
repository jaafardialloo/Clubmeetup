using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
namespace MongoDB.Dtos.UniversiteDto
{
    public class UniversiteModif
    {
       
        public string Nom { get; set; }
       
        public string Adresse { get; set; }
        public string Description { get; set; }
       
        public string Region { get; set; }
     
    }
}
