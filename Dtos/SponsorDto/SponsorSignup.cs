using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
namespace MongoDB.Dtos.SponsorDto
{
    public class SponsorSignup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Description { get; set; }
       
    }
}
