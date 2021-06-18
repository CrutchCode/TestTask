using AccountingProgrammers.Models;
using DatabaseAccounting.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountingProgrammers.Controllers
{
    public class OperationsController : Controller
    {
        private readonly IProjectRepository _dbProject;
        private readonly IUserRepository _dbUser;
        public OperationsController(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _dbProject = projectRepository;
            _dbUser = userRepository;
        }

        [HttpGet]
        public IActionResult AssignOnProject()
        {
            var projects = _dbProject.GetProjectList();
            var users = _dbUser.GetUserList();

            if (projects != null && users != null)
            {
                var viewModel = new ViewModelUserAndProject
                {
                    Projects = projects,
                    Users = users
                };
                return View(viewModel);
            }
            return View("NoSuccessful");
        }

        [HttpPost]
        public async Task<IActionResult> AssignOnProject(int? projectId, int? userId)
        {
            var project = await _dbProject.GetProjectAsync(projectId);
            var user = await _dbUser.GetUserAsync(userId);

            if (project != null && user != null)
            {
                project.Users.Add(user);
                await _dbProject.SaveAsync();
                user.Projects.Add(project);
                await _dbUser.SaveAsync();
                return RedirectToAction("Index", "Home");
            }
            return View("NoSuccessful");
        }

        [HttpGet]
        public IActionResult RemoveFromProject()
        {
            var users = _dbUser.GetUserList();
            var projects = _dbProject.GetProjectList();

            if (projects != null && users != null)
            {
                var viewModel = new ViewModelUserAndProject
                {
                    Projects = projects,
                    Users = users
                };
                return View(viewModel);
            }
            return View("NoSuccessful");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromProject(int? userId)
        {
            if (userId != null)
            {
                await _dbUser.DeleteAsync(userId);
                await _dbUser.SaveAsync();
                return RedirectToAction("Index", "Home");
            }
            return View("NoSuccessful");
        }
    }
}
