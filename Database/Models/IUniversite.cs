using System;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MongoDB.Database.Models
{
    public interface IUniversite
    {
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Nom { get; set; }
        string Adresse { get; set; }
        string Description { get; set; }
        string Region { get; set; }
        List<Ecole> Ecoles { get; set; }
    }
}