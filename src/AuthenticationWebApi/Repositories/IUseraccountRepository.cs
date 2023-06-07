using Entities = AuthenticationWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partytime.Party.Service.Repositories
{
    public interface IUseraccountRepository
    {
        Task<Entities.Useraccount> CreateUser(Entities.Useraccount user);
        Task<List<Entities.Useraccount>> GetUser(string username, string password);
    }
}
