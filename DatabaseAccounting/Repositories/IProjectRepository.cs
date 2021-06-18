using DatabaseAccounting.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccounting.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjectList();
        Task<Project> GetProjectAsync(int? id);
        Task CreateAsync(Project item);
        void Update(Project item);
        Task DeleteAsync(int? id);
        Task SaveAsync();
    }
}
