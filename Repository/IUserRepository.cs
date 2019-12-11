using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IUserRepository<T> : IRepository<T> where T : class, IClub
    {
        Task AddPostAsync(Guid id, Evenement Evenement);
    }
}
