using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildTrackMVC.Data;
using BuildTrackMVC.Models;
using System.Threading.Tasks;

namespace BuildTrackMVC.Controllers
{
    public class MateriaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiais.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var material = await _context.Materiais.FirstOrDefaultAsync(m => m.Id == id);
            if (material == null) return NotFound();
            return View(material);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,StockDisponivel")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var material = await _context.Materiais.FindAsync(id);
            if (material == null) return NotFound();
            return View(material);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,StockDisponivel")] Material material)
        {
            if (id != material.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var material = await _context.Materiais.FirstOrDefaultAsync(m => m.Id == id);
            if (material == null) return NotFound();
            return View(material);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materiais.FindAsync(id);
            if (material != null)
            {
                _context.Materiais.Remove(material);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id) => _context.Materiais.Any(e => e.Id == id);

        // API endpoint to get materials as JSON
        [HttpGet]
        public async Task<IActionResult> GetMaterialsJson()
        {
            var materiais = await _context.Materiais
                .Select(m => new { m.Id, m.Nome, m.Descricao, m.StockDisponivel })
                .ToListAsync();
            return Json(materiais);
        }
    }
}
