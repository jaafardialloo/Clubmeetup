using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IUserRepository<Club> Clubs { get; }
        public IPostRepository<Evenement> Evenements { get; }
        public IEcoleRepository<Ecole> Ecoles { get; }
        public IUniversiteRepository<Universite> Universites { get; }
        public IAdministrationRepository<Administration> Administrations { get; }
        public IDomaineRepository<Domaine> Domaines { get; }

        public RepositoryWrapper(IUserRepository<Club> users, IPostRepository<Evenement> evenements, IEcoleRepository<Ecole> ecoles,IUniversiteRepository<Universite> universites,IAdministrationRepository<Administration> administrations,IDomaineRepository<Domaine> Domaines)
        {
            Clubs = users;
            Evenements = evenements;
            Ecoles = ecoles;
            Universites = universites;
            Administrations = administrations;
            Domaines=Domaines;
        }
    }
}
