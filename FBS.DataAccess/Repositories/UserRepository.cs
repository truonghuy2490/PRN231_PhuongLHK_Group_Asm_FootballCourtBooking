using FBS.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<User>> GetUsers(string? filterField, string? filterValue);

        Task<User?> GetUserByProperties(string properties, string values);

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(User user);

        Task<User> DeleteUser(User user);
    }
    public class UserRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IUserRepository
    {
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByProperties(string properties, string values)
        {
            // let hardcode by username
            var user = await repositoryContext.Users.FirstOrDefaultAsync(x => x.UserName == values);
            return user;
        }

        public Task<List<User>> GetUsers(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
