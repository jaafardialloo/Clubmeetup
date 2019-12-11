using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IUniversiteRepository<T> : IRepository<T> where T : class, IUniversite
    {
        
        Task AddEcoleAsync(Guid id, Ecole Ecole);
    
    }
}
