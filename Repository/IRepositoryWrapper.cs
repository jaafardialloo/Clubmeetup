using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository<Club> Clubs { get; }
        IPostRepository<Evenement> Evenements { get; }
        IEcoleRepository<Ecole> Ecoles { get; }
        IUniversiteRepository<Universite> Universites { get; }
        IAdministrationRepository<Administration> Administrations { get; }
        IDomaineRepository<Domaine> Domaines {get; }
    }
}
