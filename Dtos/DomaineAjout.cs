using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
namespace MongoDB.Dtos
{
    public class DomaineAjout
    {
       
        [Required]
        public string Name{ get; set; }
        
    }
}
