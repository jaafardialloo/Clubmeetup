using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MongoDB.Repository
{
    public class EcoleRepository : IEcoleRepository<Ecole>
    {
        private readonly IMongoContext _context;

        public EcoleRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<Ecole>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                List<Ecole> evenements = new List<Ecole>();

                foreach (Universite user in _context.Universites.AsQueryable().ToList())
                {
                    evenements.AddRange(user.Ecoles);
                }

                return evenements;
            });
        }


        public async Task<Ecole> FindAsync(Guid id)
        {
            return await _context.Ecoles.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        /*public async Task<Ecole> FindAsync(Guid id)
        {
            return await _context.Universites
                .AsQueryable()
                .Select(x => x.Ecoles.FirstOrDefault(p => p.Id == id))
                .FirstOrDefaultAsync();
        }*/

        public async Task AddAsync(Ecole entity)
        {
            await _context.Ecoles.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, Ecole entity)
        {
            Ecole user = await FindAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");

            FilterDefinition<Ecole> filter = Builders<Ecole>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Ecole> update = Builders<Ecole>.Update.Set(x => x, user);

            await _context.Ecoles.UpdateOneAsync(filter, update);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Ecole user = await FindAsync(id);

            if (user is null)
                return false;

            DeleteResult result = await _context.Ecoles.DeleteOneAsync(x => x.InternalId == user.InternalId);

            return result.DeletedCount > 0;
        }

          public async Task AddEcoleAsync(Guid id, Club club)
        {
            Ecole ecole = await FindAsync(id);

            if (ecole is null)
                throw new KeyNotFoundException("Ecole not found");


            ecole.Clubs.Add(club);

            FilterDefinition<Ecole> filter = Builders<Ecole>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Ecole> update = Builders<Ecole>.Update.Set(x => x.Clubs, ecole.Clubs);

            await _context.Ecoles.UpdateOneAsync(filter, update);
        }      

        public async Task AddAdministrationAsync(Guid id, Administration administration)
        {
            Ecole ecole = await FindAsync(id);

            if (ecole is null)
                throw new KeyNotFoundException("Ecole not found");


            ecole.Administrations.Add(administration);

            FilterDefinition<Ecole> filter = Builders<Ecole>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Ecole> update = Builders<Ecole>.Update.Set(x => x.Administrations, ecole.Administrations);

            await _context.Ecoles.UpdateOneAsync(filter, update);
        }      
    }
}
