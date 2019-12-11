using Microsoft.AspNetCore.Mvc;
using MongoDB.Dtos.ClubDto;
using MongoDB.Dtos.EvenementDto;
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
    public class ClubsController : ControllerBase
    {
        
        private readonly IAccountManager<Club> _accountManager;
        private readonly IRepositoryWrapper _repository;
          private IMapper _mapper;

        public ClubsController(IAccountManager<Club> accountManager, IRepositoryWrapper repository,IMapper mapper)
        { _mapper = mapper;
            _accountManager = accountManager;
            _repository = repository;
        }

        // GET: api/clubs
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            List<Club> users = await _repository.Clubs.GetAllAsync();

            if (users.Count is 0)
                return NoContent();

            return Ok(users);
        }

        // GET: api/clubs/{id}
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            Club user = await _repository.Clubs.FindAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }


        // GET: api/clubs/{id}/evenements
        [HttpGet("{id}/evenements")]
        public async Task<IActionResult> GetUserPostsAsync([FromRoute] Guid id)
        {
            Club club = await _repository.Clubs.FindAsync(id);

            if (club is null)
                return NotFound();

            return Ok(club.Evenements);
        }

        // GET: api/clubs/evenements
        [HttpGet("evenements")]
        public async Task<IActionResult> GetEvenements()
        {
            List<Evenement> events = await _repository.Evenements.GetAllAsync();


            if (events is null)
                return NotFound();

            return Ok(events);
        }

        // POST: api/clubs/{id}/evenements
        [HttpPost("{id}/evenements")]
        public async Task<IActionResult> PostPostAsync([FromRoute] Guid id, [FromBody] EvenementAjout model)
        {
            
             
            var modela = _mapper.Map<Evenement>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Club user = await _repository.Clubs.FindAsync(id);

            if (user is null)
                return NotFound();

            await _repository.Clubs.AddPostAsync(id, modela);
            return Ok();
        }

        // POST: api/clubs/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] ClubSignin model)
        {
            var modela = _mapper.Map<Club>(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Token token = await _accountManager.SignInAsync(modela);

            if (token is null){
                Unauthorized();
                return BadRequest("Email ou Mot de passe invalide");
            }

            return Ok(token);
        }

        // POST: api/clubs/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] ClubSignup model)
        {
            var modela = _mapper.Map<Club>(model);
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

        // PUT: api/clubs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Club model)
        {
            await _repository.Clubs.UpdateAsync(id, model);
            return Ok();
        }

        // DELETE: api/clubs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            bool result = await _repository.Clubs.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
