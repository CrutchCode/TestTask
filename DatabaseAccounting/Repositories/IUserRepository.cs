using DatabaseAccounting.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccounting.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserList();
        Task<User> GetUserAsync(int? id);
        Task CreateAsync(User item);
        void Update(User item);
        Task DeleteAsync(int? id);
        Task SaveAsync();
    }
}
