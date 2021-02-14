using Microsoft.AspNetCore.Mvc;
using System;
using FirstASPMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstASPMvc.Controllers
{
    public class CategoryController: Controller
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            this._context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var teste = await _context.Categorias.ToListAsync();
            return View(teste);
        }

        public async Task<IActionResult> Show(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var categoria = await this._context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);

            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao")] Category categoria)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(categoria);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // pq não jogar direto index?
            }

            return View(categoria);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var categoria = await this._context.Categorias.FindAsync(id);
            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Category categoria)
        {
            if(id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._context.Update(categoria);
                    await this._context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!await this.CategoriaExists(categoria.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var categoria = await this._context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await this._context.Categorias
                .FindAsync(id);

            this._context.Remove(categoria);
            await this._context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private async Task<bool> CategoriaExists(int id)
        {
            return await this._context.Categorias.AnyAsync(e => e.Id == id);
        }
    }
}