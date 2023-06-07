using AuthenticationWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Partytime.Party.Service.Repositories
{
    public class UserRepository : IUseraccountRepository
    {
        private readonly UseraccountContext _context;

        public UserRepository(UseraccountContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Useraccount> CreateUser(Useraccount user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost]
        public async Task<Useraccount?> GetUser(string username, string password)
        {
            var user = await _context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();

            return user;
        }
    }
}