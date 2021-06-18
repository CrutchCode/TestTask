using DatabaseAccounting.Models;
using DatabaseAccounting.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountingProgrammers.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _dbUser;
        public UserController(IUserRepository userRepository)
        {
            _dbUser = userRepository;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User userModel)
        {
            if (userModel != null)
            {
                await _dbUser.CreateAsync(userModel);
                await _dbUser.SaveAsync();
                return RedirectToAction("Users", "Home");
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id != null)
            {
                var user = await _dbUser.GetUserAsync(id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return View("NoSuccessful");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User userModel)
        {
            if (userModel != null)
            {
                _dbUser.Update(userModel);
                await _dbUser.SaveAsync();
                return RedirectToAction("Users", "Home");
            }
            return View("NoSuccessful"); ;
        }

        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                await _dbUser.DeleteAsync(id);
                await _dbUser.SaveAsync();
                return RedirectToAction("Users", "Home");
            }
            return View("NoSuccessful"); ;
        }
    }
}
