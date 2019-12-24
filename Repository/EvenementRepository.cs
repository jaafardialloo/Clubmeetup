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
    public class EvenementRepository
    {
        ClubMeetDBContext db = new ClubMeetDBContext();
 
        //To Get all employees details      
        public List<Evenement> GetAllEvenements()
        {
            try
            {
                return db.EvenementRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
 
        //To Add new employee record      
        public void AddEvenement(Evenement evt)
        {
            try
            {
                db.EvenementRecord.InsertOne(evt);
            }
            catch
            {
                throw;
            }
        }
 
 
        //Get the details of a particular employee     
        public Evenement GetEvenementData(string id)
        {
            try
            {
                FilterDefinition<Evenement> filterEvenementData = Builders<Evenement>.Filter.Eq("Id", id);
 
                return db.EvenementRecord.Find(filterEvenementData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
 
        //To Update the records of a particluar employee     
        public void UpdateEvenment(Evenement evt)
        {
            try
            {
                db.EvenementRecord.ReplaceOne(filter: g => g.Id == evt.Id, replacement: evt);
            }
            catch
            {
                throw;
            }
        }
 
        //To Delete the record of a particular employee     
        public void DeleteEvenement(string id)
        {
            try
            {
                FilterDefinition<Evenement> evenementData = Builders<Evenement>.Filter.Eq("Id", id);
                db.EvenementRecord.DeleteOne(evenementData);
            }
            catch
            {
                throw;
            }
        }
        // To get the list of Cities 
       /*  public List<Cities> GetCityData()
        {
            try
            {
                return db.CityRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }*/
    }
}
