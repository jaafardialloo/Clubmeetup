using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IDomaineRepository<T> : IRepository<T> where T : class
    {
        Task AddDomaineAsync(Guid id, Domaine Domaine);
        //Task AddDomaineAsync(Guid id, Domaine Domaine);

    }
}
