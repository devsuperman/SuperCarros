using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SuperCarros.Models;
using SuperCarros.Data;

namespace SuperCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly Contexto _context;

        public CarrosController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);
            return View(carro);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            return View(carro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Update(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);
            return View(carro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
