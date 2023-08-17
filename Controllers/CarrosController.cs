using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SuperCarros.Viewmodels;
using SuperCarros.Models;
using SuperCarros.Data;

namespace SuperCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly Contexto _db;

        public CarrosController(Contexto db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Carros.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var carro = await _db.Carros.FirstOrDefaultAsync(m => m.Id == id);
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
                carro.DataDeRegistro = DateTime.Now;

                _db.Add(carro);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var carro = await _db.Carros.FindAsync(id);

            var viewmodel = new EditarCarroViewmodel
            {
                Id = carro.Id,
                Nome = carro.Nome,
                Ativo = carro.Ativo
            };

            return View(viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditarCarroViewmodel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var carro = await _db.Carros.FindAsync(viewmodel.Id);

                carro.Nome = viewmodel.Nome;
                carro.Ativo = viewmodel.Ativo;

                _db.Update(carro);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _db.Carros.FirstOrDefaultAsync(m => m.Id == id);
            return View(carro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _db.Carros.FindAsync(id);

            _db.Carros.Remove(carro);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
