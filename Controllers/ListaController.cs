using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practicatress.Data;

namespace Practicatress.Controllers
{

    public class ListaController : Controller
    {
        private readonly ILogger<ListaController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public ListaController(ILogger<ListaController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string? searchString)
        {
            var productos = from o in _context.DataContacto select o;
            return View(productos.ToList());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}