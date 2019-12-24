using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Database.Models;
using MongoDB.Repository;
using Microsoft.AspNetCore.Mvc;
 
namespace MongoDB.Controllers
{
    public class EvenementController : Controller
    {
        EvenementRepository objevt = new EvenementRepository();
 
        [HttpGet]
        [Route("api/Evenement/Index")]
        public IEnumerable<Evenement> Index()
        {
            return objevt.GetAllEvenements();
        }
 
        [HttpPost]
        [Route("api/Evenement/Create")]
        public void Create([FromBody] Evenement evt)
        {
            objevt.AddEvenement(evt);
        }
 
        [HttpGet]
        [Route("api/Evenement/Details/{id}")]
        public Evenement Details(string id)
        {
            return objevt.GetEvenementData(id);
        }
 
        [HttpPut]
        [Route("api/Evenement/Edit")]
        public void Edit([FromBody]Evenement evt)
        {
            objevt.UpdateEvenment(evt);
        }
 
        [HttpDelete]
        [Route("api/Evenement/Delete/{id}")]
        public void Delete(string id)
        {
            objevt.DeleteEvenement(id);
        }
 
        /* [HttpGet]
        [Route("api/Employee/GetCities")]
        public List<Cities> GetCities()
        {
            return objemployee.GetCityData();
        }*/
    }
}
