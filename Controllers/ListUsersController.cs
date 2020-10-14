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

        

        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

                if (user == null)
                {
                    return Json(new { success = false, message = "Error while deleting." });
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Delete Successfull!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { success = false, message = "Error while deleting." });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
