using MongoDB.Database.Models;
using MongoDB.Driver;

namespace MongoDB.Database
{
    public interface IMongoContext
    {
        IMongoCollection<Club> Clubs { get; }
        IMongoCollection<Ecole> Ecoles { get; }
        IMongoCollection<Universite> Universites { get; }
        IMongoCollection<Administration> Administrations { get; }
    }
}
