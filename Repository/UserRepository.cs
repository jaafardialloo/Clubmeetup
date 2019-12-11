using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class UserRepository : IUserRepository<Club>
    {
        private readonly IMongoContext _context;

        public UserRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<Club>> GetAllAsync()
        {
            return await _context.Clubs.Find(_ => true).ToListAsync();
        }
        /* public async Task<List<Club>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                List<Club> evenements = new List<Club>();

                foreach (Ecole uni in _context.Ecoles.AsQueryable().ToList())
                {
                   foreach (Club club in _context.uni.Clubs.AsQueryable().ToList())
                   {
                    evenements.AddRange(club.Clubs);
                   }
               
                }
               

                return evenements;
            });
        }
        */
        public async Task<Club> FindAsync(Guid id)
        {
            return await _context.Clubs.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Club entity)
        {
            await _context.Clubs.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, Club entity)
        {
            Club user = await FindAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");

            FilterDefinition<Club> filter = Builders<Club>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Club> update = Builders<Club>.Update.Set(x => x, user);

            await _context.Clubs.UpdateOneAsync(filter, update);
        }

        public async Task AddPostAsync(Guid id, Evenement post)
        {
            Club user = await FindAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");

            user.Evenements.Add(post);

            FilterDefinition<Club> filter = Builders<Club>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<Club> update = Builders<Club>.Update.Set(x => x.Evenements, user.Evenements);

            await _context.Clubs.UpdateOneAsync(filter, update);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Club user = await FindAsync(id);

            if (user is null)
                return false;

            DeleteResult result = await _context.Clubs.DeleteOneAsync(x => x.InternalId == user.InternalId);

            return result.DeletedCount > 0;
        }
    }
}
