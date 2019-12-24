using MongoDB.Database.Models;

using System.Threading.Tasks;

namespace MongoDB.Manager
{
    public interface IAccountManager<T> where T : class
    {
        Task<Token> SignInAsync(T model);
        Task<Token> SignUpAsync(T model);
    }
}
