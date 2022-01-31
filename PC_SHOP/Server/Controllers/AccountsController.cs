using PC_SHOP.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PC_SHOP.Server.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PC_SHOP.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;

        public AccountsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var appUserList = await _context.ApplicationUsers.ToListAsync();
            List<ClientApplicationUser> clientAppUserList = new List<ClientApplicationUser>();
            foreach (var appUser in appUserList)
            {
                ClientApplicationUser clientAppUser = new ClientApplicationUser(appUser);
                clientAppUserList.Add(clientAppUser);
            }
            return Ok(clientAppUserList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            var appUserList = await _context.ApplicationUsers.ToListAsync();
            foreach (var appUser in appUserList)
            {
                if (appUser.Id == id)
                {
                    var UserResult = await _userManager.IsInRoleAsync(appUser, "Administrator");

                    if (UserResult)
                    {
                        return Ok("Administrator");
                    }

                    UserResult = await _userManager.IsInRoleAsync(appUser, "User");

                    if (UserResult)
                    {
                        return Ok("User");
                    }
                }
            }

            return NotFound();
        }
    }
}
