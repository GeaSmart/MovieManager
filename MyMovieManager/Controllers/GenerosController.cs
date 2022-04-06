using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Controllers
{
    public class GenerosController:Controller
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var generos = await context.Generos.ToListAsync();
            return View(generos);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x=>x.Id == id);

            if (id == 0)
                return View(new Genero());

            return View(genero);
        }
    }
}
