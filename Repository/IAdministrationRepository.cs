using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public interface IAdministrationRepository<T> : IRepository<T> where T : class, IAdministration
    {

    }
}
