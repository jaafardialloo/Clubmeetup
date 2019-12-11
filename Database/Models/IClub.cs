using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
namespace MongoDB.Database.Models
{
    public interface IClub
    {
        string Email { get; set; }
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Description { get; set; }

        List<Evenement> Evenements { get; set; }
    }
}