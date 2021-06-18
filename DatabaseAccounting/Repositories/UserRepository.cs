using DatabaseAccounting.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccounting.Models
{
    public class UserRepository : IUserRepository
    {
        private DbAccountingContext _dbContext;
        public UserRepository(DbAccountingContext database)
        {
            _dbContext = database;
        }

        public async Task CreateAsync(User item)
        {
            await _dbContext.Users.AddAsync(item);
        }

        public async Task DeleteAsync(int? id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }
        }

        public async Task<User> GetUserAsync(int? id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.Include(u => u.Projects);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
