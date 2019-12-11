using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Database.Models;
using System;

namespace MongoDB.Dtos.EvenementDto
{
    public class EvenementAjout
    {
       
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }

       

      /* [BsonIgnoreIfNull]
        public virtual Club Club { get; set; }*/

        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Utc, Representation = BsonType.String)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime Date_debut_inscrit { get; set; }
        public DateTime Date_fin_inscrit { get; set; }
        public DateTime Date_validation { get; set; }
        public DateTime Date_debut_paiement { get; set; }
        public DateTime Date_fin_paiement { get; set; }
       
    }
}
