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

namespace main.Controllers
{
    public class ListUsersController : Controller
    {
        // private readonly ILogger<ListUsersController> _logger;

        // public ListUsersController(ILogger<ListUsersController> logger)
        // {
        //     _logger = logger;
        // }

        // private readonly UserManager<IdentityUser> userManager;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
