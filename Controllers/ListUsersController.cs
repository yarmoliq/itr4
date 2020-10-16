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
using Microsoft.AspNetCore.Http; // httpcontext
using Identity.Models; // ApplicationUser
using System.Security.Claims;

namespace main.Controllers
{
    public class ListUsersController : Controller
    {
        ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        IHttpContextAccessor _h;


        public ListUsersController(ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor h
        )
        {
            _context = context;
            _signInManager = signInManager;
            _h = h;
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

                var currentUserId = _h.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if(userId == currentUserId)
                {
                    await _signInManager.SignOutAsync();
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

        private async Task<bool> BlockUser(string userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

                if (user == null)
                {
                    return true;
                }

                var currentUserId = _h.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (userId == currentUserId)
                {
                    await _signInManager.SignOutAsync();
                }

                user.LockoutEnabled = true;
                user.LockoutEnd = DateTime.Now.AddHours(365 * 24);
                _context.Users.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost("ListUsers/BlockUsers")]
        public async Task<IActionResult> BlockUsers(string[] userIds)
        {
            // stoilo bi sdelat eto normalno
            // chtobi kajdii raz ne delat db.savechanges
            // no y menya net vremeni :)
            foreach (var userId in userIds)
            {
                BlockUser(userId);
            }

            return Json(new { success = true, message = "Yes." });
        }

        private async Task<bool> UnblockUser(string userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

                if (user == null)
                {
                    return true;
                }

                user.LockoutEnabled = false;
                user.LockoutEnd = null;
                _context.Users.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost("ListUsers/UnblockUsers")]
        public async Task<IActionResult> UnblockUsers(string[] userIds)
        {
            // stoilo bi sdelat eto normalno
            // chtobi kajdii raz ne delat db.savechanges
            // no y menya net vremeni :)
            foreach (var userId in userIds)
            {
                UnblockUser(userId);
            }

            return Json(new { success = true, message = "Yes." });
        }

        // public IActionResult YES()
        // {
        //     return View(h.HttpContext.User.Identity.Name);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
