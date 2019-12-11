using System;
using MongoDB.Bson;

namespace MongoDB.Database.Models
{
    public interface IEvenement
    {
        string Content { get; set; }
        DateTime CreationDate { get; set; }
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Title { get; set; }
        DateTime Date_debut_inscrit { get; set; }
        DateTime Date_fin_inscrit { get; set; }
        DateTime Date_validation { get; set; }
        DateTime Date_debut_paiement { get; set; }
        DateTime Date_fin_paiement { get; set; }
       /* Club Club { get; set; }*/
    }
}