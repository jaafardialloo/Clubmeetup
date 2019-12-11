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
    public class AdministrationRepository : IAdministrationRepository<Administration>
    {
        private readonly IMongoContext _context;

        public AdministrationRepository(IMongoContext context)
        {
            _context = context;
        }

        public Task AddAsync(Administration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Administration> FindAsync(Guid id)
        {
            return await _context.Ecoles
                .AsQueryable()
                .Select(x => x.Administrations.FirstOrDefault(p => p.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Administration>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                List<Administration> administrations = new List<Administration>();

                foreach (Ecole user in _context.Ecoles.AsQueryable().ToList())
                {
                    administrations.AddRange(user.Administrations);
                }

                return administrations;
            });
        }

        public Task UpdateAsync(Guid id, Administration entity)
        {
            throw new NotImplementedException();
        }
    }
}
