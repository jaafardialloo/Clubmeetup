using Microsoft.AspNetCore.Mvc;
//using MongoDB.Dtos.ClubDto;
//using MongoDB.Dtos.EcoleDto;
//using MongoDB.Dtos.UniversiteDto;
using MongoDB.Dtos;
using MongoDB.Database.Models;
using MongoDB.Manager;
using MongoDB.Repository;
using MongoDB.Database;
//using MongoDB.Dtos.sponsorDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Text;


namespace MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SponsorController : ControllerBase
    {
        private readonly static IMongoContext _context;
        private  SponsorRepository objSponsor=new SponsorRepository(_context);
        private IMapper _mapper;
        private readonly SponsorManager _accountManager;
       // private readonly IMongoContext _context;

        [HttpGet]
        [Route("api/Sponsor/Index")]
        public IEnumerable<Sponsor> Index()
        {
            return objSponsor.GetAllSponsors();
        }

         [HttpPost]
        [Route("api/Sponsor/Create")]
        public void Create([FromBody] Sponsor spon)
        {
            objSponsor.AddSponsor(spon);
        }

         [HttpGet]
        [Route("api/Sponsor/Details/{id}")]
        public Sponsor Details(string id)
        {
            return objSponsor.GetSponsorData(id);
        }
         [HttpPut]
        [Route("api/Sponsor/Edit")]
        public void Edit([FromBody]Sponsor Spon)
        {
            objSponsor.UpdateSponsor(Spon);
        }

        [HttpDelete]
        [Route("api/Sponsor/Delete/{id}")]
        public void Delete(string id)
        {
            objSponsor.DeleteSponsor(id);
        }


//Spondor Inscrition 
   // POST: api/Sponsor/signup
         [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] Sponsor model)
        {
            var modela = _mapper.Map<Sponsor>(model);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Token token = await _accountManager.SignUpAsync(modela);

                if (token is null)
                    return BadRequest("Could not generate token");

                return Ok(token);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Sponsor/signin

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] Sponsor model)
        {
            var modela = _mapper.Map<Sponsor>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Token token = await _accountManager.SignInAsync(modela);

            if (token is null){
                Unauthorized();
                return BadRequest("Email ou Mot de passe invalide");
            }

            return Ok(token);
        }


       
    }
}
