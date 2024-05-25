using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practicatress.Data;
using Practicatress.Models;

namespace Practicatress.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ApplicationDbContext _context;

        public UsuarioController(ILogger<UsuarioController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(Usuario objusuario)
        {
            _logger.LogDebug("Ingreso a enviar mensaje");
            _context.Add(objusuario);
            _context.SaveChanges();
            ViewData["Message"] = "Se registro el contacto";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}