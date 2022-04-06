using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieManager.Controllers
{
    public class ActoresController : Controller
    {
        private readonly ApplicationDbContext context;

        public ActoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var actores = await context.Actores.ToListAsync();
            return View(actores);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Actor());

            var actor = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            return View(actor);
        }

    }
}
