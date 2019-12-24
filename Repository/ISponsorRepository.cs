using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public interface ISponsorRepository
    {
        List<Sponsor> GetAllSponsors();

        void AddSponsor(Sponsor spon);

        Sponsor GetSponsorData(string id);

        void UpdateSponsor(Sponsor spon);

        void DeleteSponsor(string id);
    }
}
