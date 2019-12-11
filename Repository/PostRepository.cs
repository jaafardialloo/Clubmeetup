using Microsoft.EntityFrameworkCore;

using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class PostRepository : IPostRepository<Evenement>
    {
        private readonly IMongoContext _context;

        public PostRepository(IMongoContext context)
        {
            _context = context;
        }

        public Task AddAsync(Evenement entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Evenement> FindAsync(Guid id)
        {
            return await _context.Clubs
                .AsQueryable()
                .Select(x => x.Evenements.FirstOrDefault(p => p.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Evenement>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                List<Evenement> evenements = new List<Evenement>();

                foreach (Club user in _context.Clubs.AsQueryable().ToList())
                {
                    evenements.AddRange(user.Evenements);
                }

                return evenements;
            });
        }

        public Task UpdateAsync(Guid id, Evenement entity)
        {
            throw new NotImplementedException();
        }
    }
}
