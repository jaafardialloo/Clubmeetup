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
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IMongoContext _context;

        public SponsorRepository(IMongoContext context)
        {
            _context = context;
        }

         //To Get all Sponsors details      
        public List<Sponsor> GetAllSponsors()
        {
            try
            {
                return _context.Sponsors.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
       //To Add new Sponsor record      
        public void AddSponsor(Sponsor spon)
        {
            try
            {
                _context.Sponsors.InsertOne(spon);
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Sponsor     
        public Sponsor GetSponsorData(string id)
        {
            try
            {
                FilterDefinition<Sponsor> filterSponsorData = Builders<Sponsor>.Filter.Eq("Id", id);
 
                return _context.Sponsors.Find(filterSponsorData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
         //To Update the records of a particluar Sponsor    
        public void UpdateSponsor(Sponsor spon)
        {
            try
            {
                _context.Sponsors.ReplaceOne(filter: g => g.Id == spon.Id, replacement: spon);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Sponsor   
        public void DeleteSponsor(string id)
        {
            try
            {
                FilterDefinition<Sponsor> SponsorData = Builders<Sponsor>.Filter.Eq("Id", id);
                _context.Sponsors.DeleteOne(SponsorData);
            }
            catch
            {
                throw;
            }
        }
 

    }
}
//Sponsor Entity DJ