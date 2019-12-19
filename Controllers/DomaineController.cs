using Microsoft.AspNetCore.Mvc;
//using MongoDB.Dtos.ClubDto;
//using MongoDB.Dtos.EcoleDto;
//using MongoDB.Dtos.UniversiteDto;
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


namespace MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DomaineController : ControllerBase
    {
        
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;
       // private readonly IAccountManager<Club> _accountManager;
        private readonly IMongoContext _context;


        public DomaineController(IMongoContext context,IRepositoryWrapper repository,IMapper mapper)
        {   _mapper = mapper;
            _repository = repository;
           // _accountManager = accountManager;
            _context = context;
        }

        // GET: api/universites
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Domaine> Domaines = await _repository.Domaines.GetAllAsync();

            if (Domaines.Count is 0)
                return NoContent();

            return Ok(Domaines);
        }
      
        // POST: api/universites/ajout
        [HttpPost("ajout")]
        public async Task<IActionResult> AddDomaineAsync( [FromBody] DomaineAjout model)//Model for domaine ajout
        {  
            var modela = _mapper.Map<Domaine>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _repository.Domaines.AddAsync(modela);
            return Ok();
        }

           // GET: api/universites/{id}
        [HttpGet("{id}", Name = "GetDomaine")]
        public async Task<IActionResult> Get(Guid id)
        {
            Domaine Domaine = await _repository.Domaines.FindAsync(id);

            if (Domaine is null)
                return NotFound();

            return Ok(Domaine);
        }

         // GET: api/universites/{id}/ecoles
        [HttpGet("{id}/ecoles")]
        public async Task<IActionResult> GetDomaineAsync([FromRoute] Guid id)
        {
            Domaine Domaine = await _repository.Domaines.FindAsync(id);

            if (Domaine is null)
                return NotFound();

            return Ok(Domaine);
        }

         // POST: api/universites/{id}/ecoles
        [HttpPost("{id}/ecoles")]
        public async Task<IActionResult> PostDomaineAsync([FromRoute] Guid id, [FromBody] DomaineAjout model)//Model domaine
        {  
         var modela = _mapper.Map<Domaine>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Domaine Domaine = await _repository.Domaines.FindAsync(id);

            if (Domaine is null)
                return NotFound();
            
               await _repository.Domaines.AddDomaineAsync(id, modela);
            return Ok();
            
        }
         // PUT: api/universites/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Domaine model)
        {
            var modela = _mapper.Map<Domaine>(model);

            await _repository.Domaines.UpdateAsync(id, model);
            return Ok();
        }

        // DELETE: api/universites/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            bool result = await _repository.Domaines.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        } 
        
         // GET: api/universites/ecoles
      
        [HttpGet("Domaines")]
        public async Task<IActionResult> GetDomaines()
        {
            List<Domaine> events = await _repository.Domaines.GetAllAsync();
            if (events is null)
                return NotFound();
            return Ok(events);
        }
    }
}
