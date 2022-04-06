using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMovieManager.Helpers.MisGastos.Helpers;
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

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(int id,[FromForm] Genero genero)
        {
            if (ModelState.IsValid)
            {
                if (id == 0) //insertar
                {
                    context.Generos.Add(genero);
                    await context.SaveChangesAsync();
                }
                else //actualizar
                {
                    context.Generos.Update(genero);
                    await context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazor.RenderRazorViewToString(this, "_ViewAll", context.Generos.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazor.RenderRazorViewToString(this, "AddOrEdit", genero) });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            if (genero == null)
                return NotFound();

            context.Generos.Remove(genero);
            await context.SaveChangesAsync();

            return Json(new { isValid = true, html = RenderRazor.RenderRazorViewToString(this, "_ViewAll", context.Generos.ToList()) });
        }

    }
}
