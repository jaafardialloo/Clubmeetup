using Microsoft.AspNetCore.Mvc;
using MongoDB.Dtos.ClubDto;
using MongoDB.Dtos.EcoleDto;
using MongoDB.Dtos.UniversiteDto;
using MongoDB.Dtos;
using MongoDB.Database.Models;
using MongoDB.Manager;
using MongoDB.Repository;
using MongoDB.Database;
using AutoMapper;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;

using MongoDB.Driver;


using System.Text;


namespace MongoDB.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UniversitesController : ControllerBase
    {
        
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly IAccountManager<Club> _accountManager;
        private readonly IMongoContext _context;



        public UniversitesController(IMongoContext context,IRepositoryWrapper repository,IMapper mapper,IAccountManager<Club> accountManager)
        {   _mapper = mapper;
            _repository = repository;
            _accountManager = accountManager;
            _context = context;


        }

        // GET: api/universites
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            List<Universite> universites = await _repository.Universites.GetAllAsync();

            if (universites.Count is 0)
                return NoContent();

            return Ok(universites);
        }
      
        // POST: api/universites/ajout
        [HttpPost("ajout")]
        public async Task<IActionResult> AddUniversiteAsync( [FromBody] UniversiteAjout model)
        {
            
             
            var modela = _mapper.Map<Universite>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            await _repository.Universites.AddAsync(modela);
            return Ok();
        }

           // GET: api/universites/{id}
        [HttpGet("{id}", Name = "GetUniversite")]
        public async Task<IActionResult> Get(Guid id)
        {
            Universite universite = await _repository.Universites.FindAsync(id);

            if (universite is null)
                return NotFound();

            return Ok(universite);
        }

         // GET: api/universites/{id}/ecoles
        [HttpGet("{id}/ecoles")]
        public async Task<IActionResult> GetUniversiteEcolesAsync([FromRoute] Guid id)
        {
            Universite universite = await _repository.Universites.FindAsync(id);

            if (universite is null)
                return NotFound();

            return Ok(universite.Ecoles);
        }

         // POST: api/universites/{id}/ecoles
        [HttpPost("{id}/ecoles")]
        public async Task<IActionResult> PostEcoleAsync([FromRoute] Guid id, [FromBody] EcoleAjout model)
        {
            
             
            var modela = _mapper.Map<Ecole>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            

            Universite universite = await _repository.Universites.FindAsync(id);

            if (universite is null)
                return NotFound();
            
          

               await _repository.Universites.AddEcoleAsync(id, modela);
            return Ok();
            
        }
        
      

         // PUT: api/universites/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Universite model)
        {
            //var modela = _mapper.Map<Universite>(model);

            await _repository.Universites.UpdateAsync(id, model);
            return Ok();
        }

        // DELETE: api/universites/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            bool result = await _repository.Universites.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        } 
        
         // GET: api/universites/ecoles
      
        [HttpGet("ecoles")]
        public async Task<IActionResult> GetEcoles()
        {
            List<Ecole> events = await _repository.Ecoles.GetAllAsync();


            if (events is null)
                return NotFound();

            return Ok(events);
        }
    }
}
