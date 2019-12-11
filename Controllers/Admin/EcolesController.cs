using Microsoft.AspNetCore.Mvc;
using MongoDB.Dtos.ClubDto;
using MongoDB.Dtos.EcoleDto;
using MongoDB.Dtos;
using MongoDB.Database.Models;
using MongoDB.Manager;
using MongoDB.Repository;
using AutoMapper;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EcolesController : ControllerBase
    {
        
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly IAccountManager<Club> _accountManager;


        public EcolesController(IRepositoryWrapper repository,IMapper mapper,IAccountManager<Club> accountManager)
        {   _mapper = mapper;
            _repository = repository;
            _accountManager = accountManager;

        }

        // GET: api/ecoles
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            List<Ecole> users = await _repository.Ecoles.GetAllAsync();

            if (users.Count is 0)
                return NoContent();

            return Ok(users);
        }
      
        // POST: api/ecoles/ajout
        [HttpPost("ajout")]
        public async Task<IActionResult> AddEcoleAsync( [FromBody] EcoleAjout model)
        {
            
             
            var modela = _mapper.Map<Ecole>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            await _repository.Ecoles.AddAsync(modela);
            return Ok();
        }

           // GET: api/ecoles/{id}
        [HttpGet("{id}", Name = "GetEcole")]
        public async Task<IActionResult> Get(Guid id)
        {
            Ecole ecole = await _repository.Ecoles.FindAsync(id);

            if (ecole is null)
                return NotFound();

            return Ok(ecole);
        }

         // GET: api/ecoles/{id}/clubs
        [HttpGet("{id}/clubs")]
        public async Task<IActionResult> GetEcoleClubsAsync([FromRoute] Guid id)
        {
            Ecole ecole = await _repository.Ecoles.FindAsync(id);

            if (ecole is null)
                return NotFound();

            return Ok(ecole.Clubs);
        }

         // POST: api/ecoles/{id}/clubs
        [HttpPost("{id}/clubs")]
        public async Task<IActionResult> PostClubAsync([FromRoute] Guid id, [FromBody] ClubSignup model)
        {
            
             
            var modela = _mapper.Map<Club>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Ecole ecole = await _repository.Ecoles.FindAsync(id);

            if (ecole is null)
                return NotFound();

            await _repository.Ecoles.AddEcoleAsync(id, modela);
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
        

         // POST: api/ecoles/{id}/administrations
        [HttpPost("{id}/administrations")]
        public async Task<IActionResult> PostAdmininstraionAsync([FromRoute] Guid id, [FromBody] Administration model)
        {
            
             
            //var modela = _mapper.Map<Club>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Ecole ecole = await _repository.Ecoles.FindAsync(id);

            if (ecole is null)
                return NotFound();

            await _repository.Ecoles.AddAdministrationAsync(id, model);
            return Ok();
            
        }
         
        

    }
}
