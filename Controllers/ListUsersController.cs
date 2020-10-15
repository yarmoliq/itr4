using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using main.Models;

using Microsoft.AspNetCore.Authorization; // [Authorize]
using Microsoft.AspNetCore.Identity; // UserManager
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using main.Data; // for ApplicationDbContext

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace main.Controllers
{
    public class ListUsersController : Controller
    {
        ApplicationDbContext _context;

        public ListUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult List()
        {
            var users = _context.Users;

            return View(users);
        }

        private async Task<bool> DeleteUser(string userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

                if (user == null)
                {
                    return true;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost("ListUsers/DeleteUsers")]
        public async Task<IActionResult> DeleteUsers(string[] userIds)
        {
            // stoilo bi sdelat eto normalno
            // chtobi kajdii raz ne delat db.savechanges
            // no y menya net vremeni :)
            foreach (var userId in userIds)
            {
                DeleteUser(userId);
            }

            return Json(new { success = true, message = "Yes." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
