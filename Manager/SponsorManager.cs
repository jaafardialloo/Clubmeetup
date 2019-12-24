using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;
using MongoDB.Dtos.SponsorDto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Manager
{
    public class SponsorManager : IAccountManager<Sponsor>
    {
        private readonly IMongoContext _context;

        public SponsorManager(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Token> SignInAsync(Sponsor model)
        {
            // Just for demostration purposes
            Sponsor user = await _context.Sponsors.Find(x => x.login== model.login && x.password == model.password).FirstOrDefaultAsync();

            if (user is null)
                return null;

            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }

        public async Task<Token> SignUpAsync(Sponsor model)
        {
            Sponsor user = await _context
                .Sponsors
                .Find(x => x.login == model.login)
                .FirstOrDefaultAsync();

            if (user != null)
                throw new InvalidOperationException("User already exists");

            await _context.Sponsors.InsertOneAsync(model);
            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }
    }
}
