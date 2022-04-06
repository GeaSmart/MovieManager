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

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(int id, [FromForm] Actor actor)
        {
            if (ModelState.IsValid)
            {
                if (id == 0) //insert
                {
                    context.Actores.Add(actor);
                    await context.SaveChangesAsync();
                }
                else //update
                {
                    context.Actores.Update(actor);
                    await context.SaveChangesAsync();
                }
                return Json(new { isValid = true, html = RenderRazor.RenderRazorViewToString(this, "_ViewAll", context.Actores.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazor.RenderRazorViewToString(this, "AddOrEdit", actor) });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null)
                return NotFound();

            context.Actores.Remove(actor);
            await context.SaveChangesAsync();

            return Json(new { isValid = true, html = RenderRazor.RenderRazorViewToString(this, "_ViewAll", context.Actores.ToList()) });
        }
    }
}
