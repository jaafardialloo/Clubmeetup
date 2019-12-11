using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IEcoleRepository<T> : IRepository<T> where T : class, IEcole
    {
        
        Task AddEcoleAsync(Guid id, Club Club);
        Task AddAdministrationAsync(Guid id, Administration Administration);

    }
}
