using DatabaseAccounting.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccounting.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private DbAccountingContext _dbContext;
        public ProjectRepository(DbAccountingContext database)
        {
            _dbContext = database;
        }

        public async Task CreateAsync(Project item)
        {
            await _dbContext.Projects.AddAsync(item);
        }

        public async Task DeleteAsync(int? id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
            }
        }

        public async Task<Project> GetProjectAsync(int? id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public IEnumerable<Project> GetProjectList()
        {
            return _dbContext.Projects.Include(p => p.Users);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Project item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
