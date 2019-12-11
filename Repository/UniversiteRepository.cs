using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class UniversiteRepository : IUniversiteRepository<Universite>
    {
        private readonly IMongoContext _context;

        public UniversiteRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<Universite>> GetAllAsync()
        {
            return await _context.Universites.Find(_ => true).ToListAsync();
        }

        public async Task<Universite> FindAsync(Guid id)
        {
            return await _context.Universites.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Universite entity)
        {
            await _context.Universites.InsertOneAsync(entity);
        }

      
    
        public async Task UpdateAsync(Guid id, Universite entity)
        {
            Universite universite = await FindAsync(id);

            if (universite is null)
                throw new KeyNotFoundException("Université n'existe pas");
         

            FilterDefinition<Universite> filter = Builders<Universite>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Universite> update = Builders<Universite>.Update.Set(x => x, universite);

            await _context.Universites.UpdateOneAsync(filter, update);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Universite universite = await FindAsync(id);

            if (universite is null)
                return false;

            DeleteResult result = await _context.Universites.DeleteOneAsync(x => x.InternalId == universite.InternalId);

            return result.DeletedCount > 0;
        }

          public async Task AddEcoleAsync(Guid id, Ecole ecole)
        {
            Universite universite = await FindAsync(id);

            if (universite is null)
                throw new KeyNotFoundException("Universite n'existe pas");

           

            universite.Ecoles.Add(ecole);

            FilterDefinition<Universite> filter = Builders<Universite>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Universite> update = Builders<Universite>.Update.Set(x => x.Ecoles, universite.Ecoles);

            await _context.Universites.UpdateOneAsync(filter, update);
        }       

       
    }
}
