using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace MongoDB.Database.Models
{
    public class Evenement : IEvenement
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }

       

        /*[BsonIgnoreIfNull]
        public virtual Club Club { get; set; }*/

        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Utc, Representation = BsonType.String)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime Date_debut_inscrit { get; set; }
        public DateTime Date_fin_inscrit { get; set; }
        public DateTime Date_validation { get; set; }
        public DateTime Date_debut_paiement { get; set; }
        public DateTime Date_fin_paiement { get; set; }
        public Evenement(string title, string content,DateTime date_debut_inscrit,DateTime date_fin_inscrit,DateTime date_validation,DateTime date_debut_paiement,DateTime date_fin_paiement)
        {
            Title = title;
            Content = content;
            Date_debut_inscrit = date_debut_inscrit;
            Date_fin_inscrit = date_fin_inscrit;
            Date_validation = date_validation;
            Date_debut_paiement = date_debut_paiement;
            Date_fin_paiement = date_fin_paiement;
        }
    }
}
