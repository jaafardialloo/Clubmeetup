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
    public class DomaineRepository : IDomaineRepository<Domaine>
    {
        private readonly IMongoContext _context;

        public DomaineRepository(IMongoContext context)
        {
            _context = context;
        }

        public Task AddAsync(Domaine entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domaine> FindAsync(Guid id)
        {
           // return await _context.Domaines.AsQueryable().Select(x => x.Domaines.FirstOrDefault(p => p.Id == id)).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }
         

        public async Task<List<Domaine>> GetAllAsync()
        {
            /* return await Task.Run(() =>
            {
                List<Domaine> Domains = new List<Domaine>();

                foreach (Domaine user in _context.Domaines.AsQueryable().ToList())
                {
                    Domains.AddRange(user.Name);
                }

                return Domains;
            });
            */
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Domaine entity)
        {
            throw new NotImplementedException();
        }
         public Task AddDomaineAsync(Guid id, Domaine entity)
        {
            throw new NotImplementedException();
        }
    }
}
