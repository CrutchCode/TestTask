using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using DatabaseAccounting.Models;
using AccountingProgrammers.Models;
using DatabaseAccounting.Repositories;

namespace AccountingProgrammers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _dbProject;
        private readonly IUserRepository _dbUser;

        public HomeController(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _dbProject = projectRepository;
            _dbUser = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operation()
        {
            return View();
        }

        public IActionResult Project()
        {
            IEnumerable<Project> projects = _dbProject.GetProjectList();
            return View(projects);
        }

        public IActionResult Users()
        {
            IEnumerable<User> users = _dbUser.GetUserList();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
