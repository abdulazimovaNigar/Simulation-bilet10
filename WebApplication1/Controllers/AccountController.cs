using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels.UserViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController(UserManager<User> _userManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm) 
        {
            if (!ModelState.IsValid) return View(vm);

            var existUser = _userManager.FindByNameAsync(vm.Username);
            if (existUser is { })
            {
                ModelState.AddModelError("Username", "This username is already exist");
                return View(vm);
            }

            existUser = _userManager.FindByEmailAsync(vm.EmailAddress);
            if (existUser is { }) 
            {
                ModelState.AddModelError("EmailAddress", "This email address is already being used");
                return View(vm);
            }

            User newUser = new()
            {
                Fullname = vm.Fullname,
                UserName = vm.Username,
                Email = vm.EmailAddress
            };

            
            var result = await _userManager.CreateAsync(newUser, vm.Password);
            if(result.Succeeded == false) 
            {
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("", "Error occured");
                }
                return View(vm);
            }

            return Ok("ok");
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}
