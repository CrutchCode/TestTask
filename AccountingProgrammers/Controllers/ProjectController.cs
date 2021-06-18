using DatabaseAccounting.Models;
using DatabaseAccounting.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountingProgrammers.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _dbProject;
        public ProjectController(IProjectRepository projectRepository)
        {
            _dbProject = projectRepository;
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project projectModel)
        {
            if (projectModel != null)
            {
                await _dbProject.CreateAsync(projectModel);
                await _dbProject.SaveAsync();
                return RedirectToAction("Project", "Home");
            }
            return View("NoSuccessful");
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int? id)
        {
            if (id != null)
            {
                var project = await _dbProject.GetProjectAsync(id);
                if (project != null)
                {
                    return View(project);
                }
            }
            return View("NoSuccessful");
        }
        
        [HttpPost]
        public async Task<IActionResult> EditProject(Project projectModel)
        {
            if (projectModel != null)
            {
                _dbProject.Update(projectModel);
                await _dbProject.SaveAsync();
                return RedirectToAction("Project", "Home");
            }
            return View("NoSuccessful");
        }

        public async Task<IActionResult> DeleteProject(int? id)
        {
            if (id != null)
            {
                await _dbProject.DeleteAsync(id);
                await _dbProject.SaveAsync();
                return RedirectToAction("Project", "Home");
            }
            return View("NoSuccessful");
        }
    }
}
