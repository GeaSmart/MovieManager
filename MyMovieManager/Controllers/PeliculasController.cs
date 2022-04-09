using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly ApplicationDbContext context;

        public PeliculasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var peliculas = await context.Peliculas.ToListAsync();
            return View(peliculas);
        }

    }
}
