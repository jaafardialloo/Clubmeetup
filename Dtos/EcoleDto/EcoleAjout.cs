using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
namespace MongoDB.Dtos.EcoleDto
{
    public class EcoleAjout
    {
         
        
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Adresse { get; set; }
        public string Description { get; set; }
        [Required]
        public string Region { get; set; }
    }
}
