using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Manager
{
    public class AccountManager : IAccountManager<Club>
    {
        private readonly IMongoContext _context;

        public AccountManager(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Token> SignInAsync(Club model)
        {
            // Just for demostration purposes
            Club user = await _context
                .Clubs
                .Find(x => x.Email == model.Email && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user is null)
                return null;

            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }

        public async Task<Token> SignUpAsync(Club model)
        {
            Club user = await _context
                .Clubs
                .Find(x => x.Email == model.Email)
                .FirstOrDefaultAsync();

            if (user != null)
                throw new InvalidOperationException("User already exists");

            await _context.Clubs.InsertOneAsync(model);
            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }
    }
}
