using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
namespace MongoDB.Dtos.ClubDto
{
    public class ClubSignin
    {
      
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
       
        
    }
}
