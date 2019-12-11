using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
namespace MongoDB.Database.Models
{
    public interface IAdministration
    {
        string Email { get; set; }
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string Password { get; set; }
        string Description { get; set; }
        string Num_tel { get; set; }
    
    }
}